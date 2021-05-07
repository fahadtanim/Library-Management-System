using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Data;
using LibraryManagementSystem.Repositories.RepositoryInterfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories.RepositoryImplementations
{

    public class BorrowLogRepository : IBorrowLogRepository
    {
        private readonly IMongoCollection<BorrowLog> _borrowLog;
        private readonly ILibraryDatabaseSettings settings;
        
        public BorrowLogRepository(ILibraryDatabaseSettings settings)
        {
            this.settings = settings;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            
            _borrowLog = database.GetCollection<BorrowLog>(settings.BorrowLogsCollectionName);
        }
        public  BorrowLog Create(BorrowLog borrowLog)
        {
            var client = new MongoClient(this.settings.ConnectionString);
            var database = client.GetDatabase(this.settings.DatabaseName);

            IMongoCollection<Book> _book = database.GetCollection<Book>(this.settings.BooksCollectionName);
            

            _borrowLog.InsertOne(borrowLog);

            foreach (BookLog bookLog in borrowLog.BookLogs) {
                Book oldBook = _book.Find(book => book.Id == bookLog.bookId).FirstOrDefault();
                if (oldBook.Stock == 0)
                    throw new Exception("There is not enough book, 0 book in stock");
            }
            foreach (BookLog bookLog in borrowLog.BookLogs)
            {
                Book oldBook = _book.Find<Book>(book => book.Id == bookLog.bookId).FirstOrDefault();
                oldBook.Stock = oldBook.Stock - 1;
                _book.ReplaceOne(book => book.Id == oldBook.Id, oldBook);
            }
            return borrowLog;
        }

        public List<BorrowLog> Get() =>
            _borrowLog.Find(borrowLog => true).ToList();

        public BorrowLog Get(string id)=>
            _borrowLog.Find(borrowLog => borrowLog.Id == id).FirstOrDefault();

        public async Task<DBOutputList<BorrowLog>> GetAllByLibraryId(string libraryId, int pageNumber)
        {
            DBOutputList<BorrowLog> output = new DBOutputList<BorrowLog>();
            var querry = _borrowLog.Find(borrowLog => borrowLog.LibraryId == libraryId);
            output.CurrentPage = pageNumber;
            output.totalCount = await querry.CountDocumentsAsync();
            if (output.totalCount % this.settings.PageSize == 0)
                output.TotalPage = (int)(output.totalCount / this.settings.PageSize);
            else
                output.TotalPage = (int)(output.totalCount / this.settings.PageSize) + 1;
            output.Output = querry.Skip((int)((pageNumber - 1) * this.settings.PageSize)).Limit((int)this.settings.PageSize).ToList();
            output.pageSize = this.settings.PageSize;
            return output;
        }

        public bool Remove(BorrowLog borrowLogIn) =>
            _borrowLog.DeleteOne(borrowLog => borrowLog.Id == borrowLogIn.Id).IsAcknowledged;

        public bool Remove(string id) =>
            _borrowLog.DeleteOne(borrowLog => borrowLog.Id == id).IsAcknowledged;

        public Task<DBOutputList<BorrowLog>> Search(string libraryId, string userId, DateTime borrowDate, BorrowStatus borrowStatus, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public bool Update(string id, BorrowLog t)
        {
            throw new NotImplementedException();
        }

    }
}
