using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TripAgencyProject.Models
{
    [MetadataType(typeof(TripAgencyMetaData))]
    public partial class TripAgency
    {
        //add new properties
    }

    public class TripAgencyMetaData 
    {
        [Display(Name = "ID")]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "password should be atleast 8 characters")]
        public string Password { get; set; }
        public int PhoneNo { get; set; }
        public string Photo { get; set; }
        public string UserRole { get; set; }
        public int AdminID { get; set; }
    }
}