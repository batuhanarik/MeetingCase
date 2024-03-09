using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProfileImage : IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
