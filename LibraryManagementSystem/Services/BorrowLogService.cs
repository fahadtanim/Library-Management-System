using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.RepositoryInterfaces;
using LibraryManagementSystem.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class BorrowLogService : IBorrowLogService
    {
        private IBorrowLogRepository BorrowLogRepository { set; get; }
        public BorrowLogService(IBorrowLogRepository borrowLogRepository)
        {
            this.BorrowLogRepository = borrowLogRepository;
        }
        public OutputResult<BorrowLog> Delete(string id)
        {
            return new OutputResult<BorrowLog>();
        }

        public OutputResult<BorrowLog> Get(string id)
        {
            return new OutputResult<BorrowLog>();
        }

        public async Task<OutputResult<BorrowLog>> GetAllByLibraryId(string libraryId, int pageNumber)
        {
            OutputResult<BorrowLog> outputResult = new OutputResult<BorrowLog>();
            try
            {
                outputResult.MultiData = await BorrowLogRepository.GetAllByLibraryId(libraryId, pageNumber);
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

        public OutputResult<BorrowLog> Insert(InsertBorrowLogDto borrowLogDto)
        {
            OutputResult<BorrowLog> outputResult = new OutputResult<BorrowLog>();
            try
            {
                BorrowLog borrowLog = new BorrowLog();
                borrowLog.LibraryId = borrowLogDto.LibraryId;
                borrowLog.UserId = borrowLogDto.UserId;
                borrowLog.BorrowStatus = borrowLogDto.BorrowStatus;
                borrowLog.BorrowDate = borrowLogDto.BorrowDate;
                borrowLog.BookLogs = borrowLogDto.BookLogs;


                borrowLog = this.BorrowLogRepository.Create(borrowLog);

                outputResult.SingleData = borrowLog;
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

        public Task<OutputResult<BorrowLog>> Search(string libraryId, string userId, DateTime borrowDate, BorrowStatus borrowStatus, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public OutputResult<BorrowLog> Update(string id, UpdateBorrowLogDto t)
        {
            return new OutputResult<BorrowLog>();
        }

        
    }
}
