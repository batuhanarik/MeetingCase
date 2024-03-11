using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MeetingCaseContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new MeetingCaseContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public UserDetailDTO GetUserDetail(int id)
        {
            using (var context = new MeetingCaseContext())
            {
                var result = from img in context.ProfileImages
                             join u in context.Users
                             on img.UserId equals id
                             select new UserDetailDTO { Id = u.Id,Email=u.Email,FirstName=u.FirstName,LastName=u.LastName,ProfileImagePath=img.ImagePath};
                return result.FirstOrDefault();
            }
        }
    }
}
