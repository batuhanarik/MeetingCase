using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class MeetingDetailDto
    {
        public int Id { get; set; }
        public string MeetingName { get; set; }
        public string Description { get; set; }
        public string DocumentPath { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    
    }
}
