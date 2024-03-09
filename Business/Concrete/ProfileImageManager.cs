using Business.Abstract;
using Business.Constants;
using Core.Utiilites.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class ProfileImageManager : IProfileImageService
    {
        private IProfileImageDal _profileImageDal;

        public ProfileImageManager(IProfileImageDal profileImageDal)
        {
            _profileImageDal = profileImageDal;
        }

        public IResult Add(IFormFile file,ProfileImage profileImage)
        {
            //var result = BusinessRules.Run(CheckIfImageLimitExceeded(wpImage.WeddingPlaceId));
            //if (result != null)
            //{
            //    return result;
            //}
            string imageName = string.Format(@"{0}.jpg", Guid.NewGuid());
            profileImage.ImagePath = Paths.ProfileImagePath + imageName;
            profileImage.Date = DateTime.Now;
            FileHelper.Write(file, Paths.ProfileImagePath);
            _profileImageDal.Add(profileImage);
            return new SuccessResult("Profile Image Added");
        }

        public IResult Delete(ProfileImage profileImage)
        {
            ProfileImage willDeleteImage = _profileImageDal.Get(img => img.Id == img.UserId);
            string path = willDeleteImage.ImagePath;

            _profileImageDal.Delete(willDeleteImage);
            FileHelper.Delete(Paths.RootPath + path);

            return new SuccessResult("Profile Photo Deleted");
        }

        public IResult DeleteByUserId(int userId)
        {
            var result = GetImageByUserId(userId);
            if (result.Success)
            {
                Delete(result.Data);
            }
            return new SuccessResult();
        }

        public IDataResult<List<ProfileImage>> GetAll()
        {
            return new SuccessDataResult<List<ProfileImage>>(_profileImageDal.GetAll());
        }

        public IDataResult<ProfileImage> GetById(int id)
        {
            return new SuccessDataResult<ProfileImage>(_profileImageDal.Get(img => img.Id == id));
        }

        public IDataResult<ProfileImage> GetImageByUserId(int userId)
        {
            var profileImage = _profileImageDal.GetAll(img => img.UserId == userId).SingleOrDefault();

            if (profileImage != null)
            {
                return new SuccessDataResult<ProfileImage>(profileImage);
            }
            return new ErrorDataResult<ProfileImage>("No Profile Image!");

        }

        public IResult Update(ProfileImage profileImage, IFormFile file)
        {
            profileImage.Date = DateTime.Now;
            _profileImageDal.Update(profileImage);
            return new SuccessResult("Profile Image Updated!");
        }
    }
}
