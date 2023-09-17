using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IRoomDal : IGenericDal<Room> // "IGenericDal" interface'sinden miras al ve burada "Room" entity'sini kullan dedik. "Room" entity'sinden haberdar olmuş oldu. Burada hem generic olarak tanımladığımız interface içerisinde ki hem de "Room" entity'sine özgü metotları yazıcaz
    {
    }
}
