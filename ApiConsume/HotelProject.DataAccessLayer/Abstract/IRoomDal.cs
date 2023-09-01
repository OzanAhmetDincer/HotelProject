using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IRoomDal : IGenericDal<Room> // "IGenericDal" interface'sinden miras al ve burada "Room" entity'sini kullan dedik. "Room" entity'sinden haberdar olmuş oldu. Burada hem generic olarak tanımladığımız interface içerisinde ki hem de "Room" entity'sine özgü metotları yazıcaz
    {
    }
}
