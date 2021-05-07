using LibraryManagementSystem.Models;

using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using LibraryManagementSystem.Repositories.Data;
using LibraryManagementSystem.Repositories.RepositoryInterfaces;
using System.Threading.Tasks;
using LibraryManagementSystem.DTO;

namespace LibraryManagementSystem.Repositories.RepositoryImplementations
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;
        private readonly ILibraryDatabaseSettings settings;
        public UserRepository(ILibraryDatabaseSettings settings)
        {
            this.settings = settings;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }
        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }
        public async Task<DBOutputList<User>> GetAllByLibraryId(string libraryId,int pageNumber) {
            DBOutputList<User> output = new DBOutputList<User>();
            var querry = this._users.Find(user => user.LibraryId == libraryId);
            output.CurrentPage = pageNumber;
            output.totalCount = await querry.CountDocumentsAsync();
            if (output.totalCount % this.settings.PageSize == 0)
                output.TotalPage = (int) (output.totalCount / this.settings.PageSize);
            else
                output.TotalPage = (int) (output.totalCount / this.settings.PageSize)+1;
            output.Output = querry.Skip((int)((pageNumber-1)*this.settings.PageSize)).Limit((int)this.settings.PageSize).ToList();
            output.pageSize = this.settings.PageSize;
            return output;
            
    }
        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User GetByEmail(string libraryId,string email) =>
            _users.Find<User>(user => user.LibraryId == libraryId && user.Email == email).FirstOrDefault();
        public bool Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id).IsAcknowledged;
        public bool Remove(string id) =>
            _users.DeleteOne(user => user.Id == id).IsAcknowledged;

        public bool Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn).IsAcknowledged;
    }
}
