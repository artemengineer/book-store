using AutoMapper;
using BookStoreAPI.Dtos;
using BookStoreAPI.EntityFramework.Models;

namespace BookStoreAPI.Helpers
{
    
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailedDto>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<SelectedBook, BookSelectedDto>();
            CreateMap<BookSelectedDto, SelectedBook>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>();
        }
    }
}