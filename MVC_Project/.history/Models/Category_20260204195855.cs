using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Models
{
    
    public class Category
    {
        public int id { get; set; }


        [Column("varchar(50)")]
        [Required]
        public string Name { get; set; }
    }
}