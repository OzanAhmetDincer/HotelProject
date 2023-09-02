using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        //Burası Dto ile Entity'leri bağlayacağımız sınıf
        // Map işlemi sayesinde Dto sınıfındaki propertler ile entity katmanında yer alan sınıflarda ki propertiler arasında eşleşme olacak

        //AutoMapper kütüphanesi, farklı tipte olan nesneleri otomatik olarak birbirine dönüştürmemizi sağlayan kütüphanedir.

        //  AutoMapper kütüphanesi, farklı tipte olan nesneleri otomatik olarak birbirine dönüştürmemizi sağlayan kütüphanedir. Örnek vermek gerekirse, veri tabanımızdan verilerimizi çektiğimizi düşünelim.Bu verileri çekerken Category nesnemiz bulunuyor.Fakat direkt olarak veri tabanı nesneleri ile işlem yapmak istemiyoruz.Çünkü içerisinde diğer bilgilerimiz de bulunabilir. Farklı bir nesne oluşturarak sadece gerekli alanların görünmesi için property’lerimizi ekleyerek gösterim sağlamak istiyoruz.Bunun için de CategoryDto nesnemiz var diyelim.Category nesnemizi CategoryDto nesnemize atama yaparak gösterim sağlamak istiyoruz.Bu işlemi sağlayabilmek için ilgili nesnenin property’lerine atama işlemi yapmamız gerekiyor.Bu işlem de kod tarafında hem yorucu hem de kod fazlalığı ve kirliliğine sebep oluyor.

        // İlk önce HotelProject.Web.Api projemize nuget olarak AutoMapper ile ilgili uzantıları eklarız, sonrasında bağlatıları yapacağımız bu sınıfı oluşturduk bu sınıfıda "Profile" class'ından türetiriz ve aşağıda olduğu gibi bağlantıları yaparız.
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<UpdateRoomDto,Room>().ReverseMap();// Yukarıda ki şekilde tanımlamak yerine "ReverseMap" ile tek seferde tanımlama yaparız
        }
    }
}
