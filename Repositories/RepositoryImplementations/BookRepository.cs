using LibraryManagementSystem.Repositories.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.RepositoryInterfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.DTO;

namespace LibraryManagementSystem.Repositories.RepositoryImplementations
{
    public class BookRepository:IBookRepository
    {
        private readonly IMongoCollection<Book> _books;
        private readonly ILibraryDatabaseSettings settings;

        public BookRepository(ILibraryDatabaseSettings settings)
        {
            this.settings = settings;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public List<Book> Get() =>
            _books.Find(book => true).ToList();
        async public Task <DBOutputList<Book>> GetAllByLibraryId(string libraryId,int pageNumber) {
            DBOutputList<Book> output = new DBOutputList<Book>();
            var querry = _books.Find(book => book.LibraryId == libraryId);
            output.CurrentPage = pageNumber;
            output.totalCount = await querry.CountDocumentsAsync();
            if (output.totalCount % this.settings.PageSize == 0)
                output.TotalPage = (int) (output.totalCount / this.settings.PageSize);
            else
                output.TotalPage = (int)(output.totalCount / this.settings.PageSize)+1;
            output.Output = querry.Skip((int)((pageNumber-1)*this.settings.PageSize)).Limit((int)this.settings.PageSize).ToList();
            output.pageSize = this.settings.PageSize;
            return output;
        }
        public Book Get(string id) =>
            _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public bool Update(string id, Book bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn).IsAcknowledged;

        public bool Remove(Book bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id).IsAcknowledged;

        public bool Remove(string id) =>
            _books.DeleteOne(book => book.Id == id).IsAcknowledged;

        
    }
}
