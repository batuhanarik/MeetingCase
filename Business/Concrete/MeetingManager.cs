using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MeetingManager : IMeetingService
    {
        private IMeetingDal _meetingDal;

        public MeetingManager(IMeetingDal meetingDal)
        {
            _meetingDal = meetingDal;
        }

        [SecuredOperation("superadmin,admin,product_manager")]
        public IResult Add(Meeting meeting)
        {
            _meetingDal.Add(meeting);
            return new SuccessDataResult<Meeting>(meeting, "The meeting has been added successfully.");
        }

        [SecuredOperation("superadmin,admin,product_manager")]
        public IResult Delete(Meeting meeting)
        {
            _meetingDal.Delete(meeting);
            return new SuccessResult("The meeting has been deleted.");
        }

        public IDataResult<List<Meeting>> GetAll()
        {
            var result = _meetingDal.GetAll();
            return new SuccessDataResult<List<Meeting>>(result);
        }

      

        public IDataResult<Meeting> GetById(int id)
        {
            var result = _meetingDal.Get(m => m.Id == id);
            return new SuccessDataResult<Meeting>(result);
        }

        public IDataResult<List<MeetingDetailDto>> GetMeetingDetails()
        {
            var result = _meetingDal.GetMeetingDetails();
            return new SuccessDataResult<List<MeetingDetailDto>>(result);
        }

        [SecuredOperation("superadmin,admin,product_manager")]
        public IResult Update(Meeting meeting)
        {
            _meetingDal.Update(meeting);
            return new SuccessResult("The meeting has been updated.");
        }
    }
}
