using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli_ENTITIES
{
    public class Ogrenci
    {
        public int OgrenciID { get; set; }
        [Required]
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [StringLength(200)]
        public string Adres { get; set; }
        public int Yas { get; set; }

        [ForeignKey("Sinif")]
        public int Kademe { get; set; }
        public string Sube { get; set; }
        public Sinif Sinif { get; set; }
    }
}
