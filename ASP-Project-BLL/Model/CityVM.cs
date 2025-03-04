﻿using ASP_Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Model
{
   public class CityVM
    {
        public int Id { get; set; }
        public string CityName { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country country { get; set; }

        public ICollection<District> District { get; set; }
    }
}
