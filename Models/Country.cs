using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Country
    {
        [Key]
        public int Countryid { get; set; }
        public string Countryname { get; set; }
    }
}
