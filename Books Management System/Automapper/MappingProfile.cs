using AutoMapper;
using Books_Management_System.DTOs;
using Books_Management_System.Models;

namespace Books_Management_System.Automapper
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
		}
    }
}
