using Katmanli_ENTITIES;
using Katmanli_REP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli_BL
{
    //Business Layer: iş kuralları yazılır. Karar mekanizmasaıdır

    public class Repository
    {
        public class OgrenciRepository : BaseRepository<Ogrenci>
        {

        }

        public class SinifRepository : BaseRepository<Sinif>
        {

        }
    }
}
