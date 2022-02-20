using System;
using System.ComponentModel.DataAnnotations;
namespace Zadanie2.Models
{
    public class Details
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nie może być puste")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "NIP powinien zawierac 10 znaków.")]
        public string NIP { get; set; }
        public string RequestType { get; set; }
        public string ClientIPAdress { get; set; }
        public DateTime dateTime { get; set; }
    }
}
