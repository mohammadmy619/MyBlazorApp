using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Common
{
    public class BaseEntity
    {
        [Key]
        public int NewsId { get; set; }
        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public string EditedBy { get; set; }
    }
}
