
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(UserUpdateDto user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int UserId);
        IDataResult<List<string>> GetAllEmails();
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<UserDetailDTO> GetUserDetail(int id);
    }
}
