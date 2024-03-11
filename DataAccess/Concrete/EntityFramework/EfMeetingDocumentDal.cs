using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMeetingDocumentDal : EfEntityRepositoryBase<MeetingDocument, MeetingCaseContext>, IMeetingDocumentDal
    {
    }
}
