using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripApp.Models
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.Date)]
        public DateTime Tarih { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan"), MinLength(80,ErrorMessage ="En az 100 karakter girmelisiniz.")]
        public string Aciklama { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string BlogImage { get; set; }
        public ICollection<Yorumlar> Yorumlars { get; set; }
    }
}