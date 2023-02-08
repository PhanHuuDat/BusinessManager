using AutoMapper;
using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<BookCost, BookCostDTO>().ReverseMap();
            CreateMap<BookSize, BookSizeDTO>().ReverseMap();
            CreateMap<BookTag, BookTagDTO>().ReverseMap();
            CreateMap<Publisher, PublisherDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<BookBookTag, BookBookTagDTO>().ReverseMap();
        }
    }
}
