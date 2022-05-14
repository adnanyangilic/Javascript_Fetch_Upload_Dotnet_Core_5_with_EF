using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Javascript_Fetch_Upload_Dotnet_Core_5_with_EF.Models
{
    public class Imagemodel
    {
        [Key]
        public int ImagemodelId { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        public string ImagemodelName { get; set; }

        [Required]
        [Display(Name = "Image Comment")]
        public string ImagemodelComment { get; set; }


        [NotMapped]
        public IFormFile Imageitself { get; set; }

    }
}
