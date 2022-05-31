using Katmanli_ENTITIES;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli_DAL
{
    //Veri erişim katmanıdır. Veri 
    public class DataContext :DbContext
    {
        public DbSet<Ogrenci> Ogrenciler  { get; set; }
        public DbSet<Sinif> Siniflar  { get; set; }
    }
}
