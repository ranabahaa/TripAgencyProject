using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TripAgencyProject.Models
{
    [MetadataType(typeof(PostMetaData))]
    public partial class Post
    {
        //add methods or add new properties

    }

    public class PostMetaData
    {
        //edit properties
        [Display(Name ="ID")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "The Post")]
        [Required]
        public string Post1 { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString ="{0:D}" , ApplyFormatInEditMode =false)]
        [DataType(DataType.Date)]
        public System.DateTime PostDate { get; set; }

        [Required]
        public string TripTitle { get; set; }

        [Required]
        public string TripDetails { get; set; }

        [Required]
        public string TripDestination { get; set; }

        [DisplayFormat(DataFormatString ="{0:N}",ApplyFormatInEditMode =false)]
        public double TripPrice { get; set; }
        public string TripImage { get; set; }
        public int AgencyID { get; set; }

        public virtual TripAgency TripAgency { get; set; }
    }
} 