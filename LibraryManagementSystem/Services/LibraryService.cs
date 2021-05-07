using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.RepositoryInterfaces;
using LibraryManagementSystem.Services.ServiceInterfaces;
using encryptLibrary = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class LibraryService : ILibraryService
    {
        private ILibraryRepository LibraryRepository { set; get; }
        private IJWTTokenManager JWTTokenManager { set; get; }
        public LibraryService(ILibraryRepository libraryRepository, IJWTTokenManager jwtTokenManager)
        {
            this.LibraryRepository = libraryRepository;
            this.JWTTokenManager = jwtTokenManager;
        }
        

        public OutputResult<Library> Get(string id)
        {
            OutputResult<Library> outputResult = new OutputResult<Library>();
            try
            {
                outputResult.SingleData = this.LibraryRepository.Get(id);
                outputResult.Status = "OK";
                outputResult.Message = "";
            }

            catch (Exception e)
            {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
            }

            return outputResult;

        }

        public TokenOutputResult SignIn(string username, string password) {
            TokenOutputResult outputResult = new TokenOutputResult();
            try
            {
                Library library = this.LibraryRepository.GetByUsername(username);
                if(library!= null)
                {
                    bool verified = encryptLibrary.Verify(password, library.Password);
                    if (verified)
                    {
                        outputResult.Status = "OK";
                        outputResult.Token = this.JWTTokenManager.GenerateToken(username);
                        return outputResult;
                    }
                    outputResult.Status = "FAILED";
                    outputResult.Message = "Incorrect Username or Password";
                    
                }
            }
            catch(Exception e)
            {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
                
            }
            return outputResult;
        }

        public OutputResult<Library> Insert(InsertLibraryDto libraryDto)
        {
            OutputResult<Library> outputResult = new OutputResult<Library>();
            try
            {
                Library library = new Library();
                library.Name = libraryDto.Name;
                library.Username = libraryDto.Username;
                library.Password = encryptLibrary.HashPassword(libraryDto.Password);
                library.Phone = libraryDto.Phone;
                library = this.LibraryRepository.Create(library);

                outputResult.SingleData = library;
                outputResult.Status = "OK";
                outputResult.Message = "";

            }
            catch (Exception e)
            {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
            }

            return outputResult;
        }

        public OutputResult<Library> Update(string id, UpdateLibraryDto libraryDto)
        {
            OutputResult<Library> outputResult = new OutputResult<Library>();
            try
            {
                Library library = new Library();
                library.Name = libraryDto.Name;
                library.Username = libraryDto.Username;
                library.Password = encryptLibrary.HashPassword(libraryDto.Password);
                library.Phone = libraryDto.Phone;
                library = this.LibraryRepository.Create(library);

                outputResult.SingleData = library;
                outputResult.Status = "OK";
                outputResult.Message = "";

            }
            catch (Exception e)
            {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
            }

            return outputResult;
        }
        public OutputResult<Library> Delete(string id)
        {
            OutputResult<Library> outputResult = new OutputResult<Library>();
            outputResult.Status = "FAILED";
            outputResult.Message = "Not Allowed! Library Can't be deleted";

            return outputResult;

        }
    }
}
