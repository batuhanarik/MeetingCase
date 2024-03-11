using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMeetingDal : EfEntityRepositoryBase<Meeting, MeetingCaseContext>, IMeetingDal
    {
        public List<MeetingDetailDto> GetMeetingDetails()
        {
            using (var context = new MeetingCaseContext())
            {
                var result = from m in context.Meetings
                             join doc in context.MeetingDocuments
                             on m.Id equals doc.MeetingId into meetingDocuments
                             from subDoc in meetingDocuments.DefaultIfEmpty()
                             select new MeetingDetailDto
                             {
                                 Id = m.Id,
                                 MeetingName = m.MeetingName,
                                 Description = m.Description,
                                 StartDate = m.StartDate,
                                 EndDate = m.EndDate,
                                 DocumentPath = subDoc != null ? subDoc.DocumentPath : String.Empty
                             };
                return result.ToList();
            }
        }
    }
}
