using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BackEnd.Models
{
    public class Desc
    {
            [Key]
            public int Descid { get; set; }
            public string CategoryName { get; set; }
            public string description { get; set; }
            public int Registrationid { get; set; }
    }
}
