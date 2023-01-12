using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Uploads
    {
        [Key]
        public int Uploadsid { get; set; }
        public string category { get; set; }
        public string videofile { get; set; }
    }
}
