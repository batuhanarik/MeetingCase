using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMeetingService
    {
        IDataResult<List<Meeting>> GetAll();
        IDataResult<Meeting> GetById(int id);
        //IDataResult<List<Meeting>> GetAllByCategoryId(int id);
        IDataResult<List<MeetingDetailDto>> GetMeetingDetails();
        IResult Add(Meeting meeting);
        IResult Update(Meeting meeting);
        IResult Delete(Meeting meeting);
    }
}
