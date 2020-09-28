using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class MunicipalityModel
    {
        [Required(ErrorMessage = "Enter a value")]
        [MaxLength(100,ErrorMessage ="Name cannot be more than 100 chars")]
        public string MunicipalityName { get; set; }

        [Required(ErrorMessage = "Enter a value")]
        [DataType(DataType.DateTime,ErrorMessage ="Please enter correct Date format")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Enter a value")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter correct Date format")]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Enter a value")]        
        public Double Tax { get; set; }
    }
}
