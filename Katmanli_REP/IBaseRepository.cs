using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli_REP
{
    interface IBaseRepository<T> where T : class, new()
    {
        DbSet<T> Set();
        List<T> Listele();
        T Bul(int id);
        T Bul(string id);
        IQueryable<T> GenelListe();
        void Ekle(T entity);
        void Sil(T entitiy);
        void Guncel();
        int Etkilenenkayit();
    }
}
