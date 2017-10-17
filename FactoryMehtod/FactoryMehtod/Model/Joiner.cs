using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactoryMehtodLib.Model
{
    public class Joiner
    {
        [Key]
        public int Joiner_Id { get; set; }
        public string SiteUrl { get; set; }
    }
}
