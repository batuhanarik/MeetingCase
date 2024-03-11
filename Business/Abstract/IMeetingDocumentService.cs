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
    public interface IMeetingDocumentService
    {
        IDataResult<List<MeetingDocument>> GetAll();
        IDataResult<MeetingDocument> GetById(int id);
        IDataResult<MeetingDocument> GetDocumentByMeetingId(int meetingId);
        IResult Add(IFormFile[] files, MeetingDocument meetingDocument);
        IResult Delete(MeetingDocument meetingDocument);
        IResult DeleteByMeetingId(int meetingId);
        IResult Update(MeetingDocument meetingDocument, IFormFile[] files);
    }
}
