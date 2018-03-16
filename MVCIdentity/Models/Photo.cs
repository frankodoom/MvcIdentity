using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCIdentity.Models
{
    public class Photo
    {
        [Key]
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FIleSize { get; set; }
        public string FileType { get; set; }
        public string ImageUrl { get; set; }

    }
}