﻿using ASP_Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Model
{
   public class DistrictVM
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]  
        public virtual City City { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
