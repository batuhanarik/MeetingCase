using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProfileImageService
    {
        IDataResult<List<ProfileImage>> GetAll();
        IDataResult<ProfileImage> GetById(int id);
        IDataResult<ProfileImage> GetImageByUserId(int userId);
        IResult Add(ProfileImage profileImage, IFormFile file);
        IResult Delete(ProfileImage profileImage);
        IResult DeleteByUserId(int userId);
        IResult Update(ProfileImage profileImage, IFormFile file);
    }
}
