using Domin.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.entites
{
    public class News:  BaseEntity
    {
  
        [MaxLength(300)]
        [Required]
        public string Title { get; set; }

        [MaxLength(500)]
        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        [MaxLength(300)]
        [Required]
        public string ImageName { get; set; }

   
    }
}
