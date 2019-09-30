using AutoMapper;
using BookStoreAPI.Dtos;
using BookStoreAPI.Models;

namespace BookStoreAPI.Data
{
    public class AutoMapperProfiles : Profile // TODO: Что-то не нашёл, как это используется :)
        // TODO: Answer: 
        // TODO: Answer: библиотеку AutoMapper.Extensions.Microsoft.DependencyInjection регистрируем в файле Startup  -  services.AddAutoMapper(typeof(Startup));
        // TODO: метод .AddAutoMapper() требует любой класс сборки, по туториалу видел берут входной класс Startup
        // TODO: Этот метод ищет классы наследованные от класса Profile. 

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