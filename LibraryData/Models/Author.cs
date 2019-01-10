using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public Book Books { get; set; }
        
    }
}
