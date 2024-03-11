using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.DTOs;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        [SecuredOperation("superadmin")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int UserId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == UserId));
        }

        public IDataResult<User> GetByMail(string email)
        {

            var result = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<string>> GetAllEmails()
        {   
            List<string> emails = new List<string>();
            var result = _userDal.GetAll();
            foreach (var user in result)
            {
                emails.Add(user.Email);
            }
            return new SuccessDataResult<List<string>>(emails);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(UserUpdateDto user)
        {
            var userToUpdate = GetByMail(user.Email).Data;
            
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            _userDal.Update(userToUpdate);
            return new SuccessResult("Profile Informations Updated.");
        }

        public IDataResult<UserDetailDTO> GetUserDetail(int id)
        {
            var result = _userDal.GetUserDetail(id);
            return new SuccessDataResult<UserDetailDTO>(result);
        }
    }
}
