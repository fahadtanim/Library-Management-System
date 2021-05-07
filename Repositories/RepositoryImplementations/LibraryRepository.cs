using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Data;
using LibraryManagementSystem.Repositories.RepositoryInterfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Repositories.RepositoryImplementations
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly IMongoCollection<Library> _libraries;
        private readonly ILibraryDatabaseSettings settings;

        public LibraryRepository(ILibraryDatabaseSettings settings)
        {
            this.settings = settings;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _libraries = database.GetCollection<Library>(settings.LibrariesCollectionName);
        }
        public Library Create(Library libraryIn)
        {
            long oldLibrary = _libraries.Find(library => library.Username == libraryIn.Username).CountDocuments();
            if(oldLibrary > 0)
                throw new Exception("Username Exists");
            else
            {
                _libraries.InsertOne(libraryIn);
                return libraryIn;
            }
        }

        public List<Library> Get() =>
            _libraries.Find(library => true).ToList();
        public Library Get(string id) =>
            _libraries.Find(library => library.Id == id).FirstOrDefault();

        public Library GetByUsername(string username) =>
            _libraries.Find(library => library.Username == username).FirstOrDefault();

        public bool Update(string id, Library libraryIn) =>
            _libraries.ReplaceOne(library => library.Id == id, libraryIn).IsAcknowledged;

        public bool Remove(Library libraryIn) =>
            _libraries.DeleteOne(library => library.Id == libraryIn.Id).IsAcknowledged;

        public bool Remove(string id) =>
            _libraries.DeleteOne(library => library.Id == id).IsAcknowledged;

        
    }
}
