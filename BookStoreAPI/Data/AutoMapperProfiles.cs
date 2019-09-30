using AutoMapper;
using BookStoreAPI.Dtos;
using BookStoreAPI.Models;

namespace BookStoreAPI.Data
{
    public class AutoMapperProfiles : Profile // TODO: Что-то не нашёл, как это используется :)
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