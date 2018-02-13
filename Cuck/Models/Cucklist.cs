using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuck.Models
{
    public class Cucklist
    {
        [Key]
        [DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }
        public string ListType { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        [StringLength ( 50 )]
        public string Description { get; set; }
        public string Rating { get; set; }
        [Required]
        public ApplicationUser Owner { get; set; }
        [Required]
        [DisplayFormat]
        public DateTime CucklistDate { get; set; }


        Cucklist( )
        {


        }

        Cucklist( ApplicationUser owner )
        {
            Owner = owner;


        }

        public Cucklist( ApplicationUser owner,string listtype,string title,string topic )
        {

            Owner = owner;
            ListType = listtype;
            Title = title;
            Topic = topic;


        }
    }
}
