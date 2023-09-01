using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        //Burası Dto ile Entity'leri bağlayacağımız sınıf
        // Map işlemi sayesinde Dto sınıfındaki propertler ile entity katmanında yer alan sınıflarda ki propertiler arasında eşleşme olacak
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<UpdateRoomDto,Room>().ReverseMap();// Yukarıd ki şekilde tanımlamak yerine "ReverseMap" ile tek seferde tanımlama yaparız
        }
    }
}
