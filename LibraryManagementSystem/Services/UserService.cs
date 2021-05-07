using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.ServiceInterfaces;
using LibraryManagementSystem.Repositories.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { set; get; }
        public UserService(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }

        public async Task<OutputResult<User>> GetAllFromLibrary(string id,int pageNumber)
        {
            OutputResult<User> outputResult = new OutputResult<User>();
            try
            {
                
                outputResult.MultiData = await this.UserRepository.GetAllByLibraryId(id,pageNumber);
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



        public OutputResult<User> Get(string id)
        {
            OutputResult<User> outputResult = new OutputResult<User>();
            try
            {
                
                outputResult.SingleData = this.UserRepository.Get(id);
                outputResult.Status = "OK";
                outputResult.Message = "";
                //outputResult.MultiData = new DBOutputList<User>();
            }
            catch (Exception e)
            {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
                //outputResult.MultiData = new DBOutputList<User>();

            }

            return outputResult;
        }

        public OutputResult<User> GetByEmail(string libraryId, string email)
        {
            OutputResult<User> outputResult = new OutputResult<User>();
            try
            {

                outputResult.SingleData = this.UserRepository.GetByEmail(libraryId,email);
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

        public OutputResult<User> Insert(InsertUserDto userDTO)
        {
            OutputResult<User> outputResult = new OutputResult<User>();
            try
            {
                OutputResult<User> result = this.GetByEmail(userDTO.LibraryId, userDTO.Email);
                if (result.Status == "OK" && result.SingleData != null)
                {
                    outputResult.Status = "FAILED";
                    outputResult.Message = "User with same email exists.";
                }
                else { 
                    User user = new User();
                    user.Name = userDTO.Name;
                    user.DateOfBirth = userDTO.DateOfBirth;
                    user.Email = userDTO.Email;
                    user.Phone = userDTO.Phone;
                    user.LibraryId = userDTO.LibraryId;
                    user = this.UserRepository.Create(user);

                    outputResult.SingleData = user;
                    outputResult.Status = "OK";
                    outputResult.Message = "";

                }

            }
            catch (Exception e)
            {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
            }

            return outputResult;
        }

        public OutputResult<User> Update(string id, UpdateUserDto userDTO)
        {
            OutputResult<User> outputResult = new OutputResult<User>();
            try
            {
                User user = new User();
                user.Id = id;
                user.Name = userDTO.Name;
                user.DateOfBirth = userDTO.DateOfBirth;
                user.Email = userDTO.Email;
                user.Phone = userDTO.Phone;
                user.LibraryId = userDTO.LibraryId;
                bool result = this.UserRepository.Update(id, user);
                if (result)
                {
                    outputResult.Status = "OK";
                }
                else
                {
                    outputResult.Status = "Failed";
                }
                outputResult.Message = result.ToString();
            }

            catch (Exception e)
            {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
            }

            return outputResult;
        }

        public OutputResult<User> Delete(string id)
        {

            OutputResult<User> outputResult = new OutputResult<User>();
            try
            {
                bool result = this.UserRepository.Remove(id);
                if (result)
                {
                    outputResult.Status = "OK";
                }
                else
                {
                    outputResult.Status = "Failed";
                }
                outputResult.Message = result.ToString();
            }

            catch (Exception e)
            {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
            }

            return outputResult;
        }

    }

}
