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
            throw new NotImplementedException();
        }

        [SecuredOperation("superadmin,admin,product_manager")]
        public IResult DeleteByMeetingId(int meetingId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<MeetingDocument>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<MeetingDocument> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<MeetingDocument> GetDocumentByMeetingId(int meetingId)
        {
            var result = _meetingDocumentDal.Get(x=> x.MeetingId == meetingId);

            return new SuccessDataResult<MeetingDocument>(result,"Listed Meeting Documents");
        }

        [SecuredOperation("superadmin,admin,product_manager")]
        public IResult Update(MeetingDocument meetingDocument, IFormFile[] files)
        {
            throw new NotImplementedException();
        }
    }
}
