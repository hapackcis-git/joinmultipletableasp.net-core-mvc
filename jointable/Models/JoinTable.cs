
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace jointable.Models
{
    
    public class JoinTable
    {
        [Key]
        public int countryID { get; set; }
        public string countryName { get; set; }
        public string stateName { get; set; }
        public string cityName { get;set; }

    }
}
