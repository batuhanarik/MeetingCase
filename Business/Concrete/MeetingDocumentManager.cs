using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using Core.Utiilites.Helpers;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class MeetingDocumentManager : IMeetingDocumentService
    {
        private IMeetingDocumentDal _meetingDocumentDal;

        public MeetingDocumentManager(IMeetingDocumentDal meetingDocumentDal)
        {
            _meetingDocumentDal = meetingDocumentDal;
        }

        [SecuredOperation("superadmin,admin,product_manager")]
        public IResult Add(IFormFile[] files, MeetingDocument meetingDocument)
        {
            var zipFilePath = DocumentHelper.CompressDocuments(files);

            meetingDocument.DocumentPath= zipFilePath;
            meetingDocument.Date = DateTime.Now;

            _meetingDocumentDal.Add(meetingDocument);
            return new SuccessResult("Meeting Documents Added");
        }

        [SecuredOperation("superadmin,admin,product_manager")]
        public IResult Delete(MeetingDocument meetingDocument)
        {
            _meetingDocumentDal.Delete(meetingDocument);
            return new SuccessResult("Document Deleted!");

        }

        [SecuredOperation("superadmin,admin,product_manager")]
        public IResult DeleteByMeetingId(int meetingId)
        {
            var result = _meetingDocumentDal.Get(x => x.MeetingId == meetingId);
            _meetingDocumentDal.Delete(result);
            return new SuccessResult("Document Deleted!");
        }

        public IDataResult<List<MeetingDocument>> GetAll()
        {
            var result = this._meetingDocumentDal.GetAll();
            return new SuccessDataResult<List<MeetingDocument>>(result, "Listed Meeting Documents");

        }

        public IDataResult<MeetingDocument> GetById(int id)
        {
            var result = _meetingDocumentDal.Get(x => x.Id == id);
            return new SuccessDataResult<MeetingDocument>(result, "Get Meet Document");
        }

        
        [SecuredOperation("superadmin,admin,product_manager")]
        public IDataResult<MeetingDocument> GetDocumentByMeetingId(int meetingId)
        {
            var result = _meetingDocumentDal.Get(x=> x.MeetingId == meetingId);

            return new SuccessDataResult<MeetingDocument>(result,"Get Meet Document");
        }

        [SecuredOperation("superadmin,admin,product_manager")]
        public IResult Update(MeetingDocument meetingDocument, IFormFile[] files)
        {

            var zipFilePath = DocumentHelper.CompressDocuments(files);
            meetingDocument.DocumentPath = zipFilePath;
            meetingDocument.Date = DateTime.Now;

            _meetingDocumentDal.Update(meetingDocument);
            return new SuccessResult("Meeting Documents Updated");
        }
    }
}
