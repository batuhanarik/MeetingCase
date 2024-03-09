using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Delete(Meeting meeting)
        {
            //_meetingDal.DeleteByWeddingPlaceId(meeting.Id);
            _meetingDal.Delete(meeting);
            return new SuccessResult("The meeting has been deleted.");
        }

        public IDataResult<List<Meeting>> GetAll()
        {
            var result = _meetingDal.GetAll();
            return new SuccessDataResult<List<Meeting>>(result);
        }

        public IDataResult<List<Meeting>> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Meeting> GetById(int id)
        {
            var result = _meetingDal.Get(m => m.Id == id);
            return new SuccessDataResult<Meeting>(result);
        }

        public IResult Update(Meeting meetings)
        {
            _meetingDal.Update(meetings);
            return new SuccessResult("The meeting has been updated.");
        }
    }
}
