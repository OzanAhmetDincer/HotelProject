using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class// "<T>" dışarıdan bir "T" değeri alacak ve bu değer bir class olacak "where T : class"
    {
        void Insert(T t);// Ekleme
        void Delete(T t);// Silme
        void Update(T t);// Güncelleme
        List<T> GetList();// Liste türünde "T" parametresi alan "GetList" isminde bir listeleme işlemi
        T GetByID(int id);// "T" türünde "GetById" isminde int türünde id değişkeni alan metot
    }
}
