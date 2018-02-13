using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using DataAnnotationsExtensions;

namespace Cuck.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
        public int ImageId { get; set; }
        [Date]
        [DisplayFormat]
        public DateTime ImageDate { get; set; }
        [Required]
        public ApplicationUser ImageOwner { get; set; }
        [System.ComponentModel.DataAnnotations.Url]
        [DisplayFormat]
        public string Url { get; set; }
        [StringLength ( 100 )]
        public string ImageDescription { get; set; }


    }
}
