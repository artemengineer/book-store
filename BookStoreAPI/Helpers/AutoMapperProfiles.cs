using AutoMapper;
using BookStoreAPI.Dtos;
using BookStoreAPI.EntityFramework.Models;

namespace BookStoreAPI.Helpers
{
    // TODO: Что-то не нашёл, как это используется :)
    /**
     * Answer:
     * Библиотеку AutoMapper.Extensions.Microsoft.DependencyInjection регистрируем в файле Startup  -  services.AddAutoMapper(typeof(Startup));
     * Метод .AddAutoMapper() требует любой класс сборки, по туториалу видел берут входной класс Startup
     * Этот метод ищет классы наследованные от класса Profile. 
     */
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