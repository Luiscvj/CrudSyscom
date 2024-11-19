using AutoMapper;
using LibraryCrud.Api.DTOS.AuthorDTOS;
using LibraryCrud.Api.DTOS.BookDTOS;
using LibraryCrud.Api.DTOS.GenreDTOS;
using LibraryCrud.Domain.Entities;

namespace LibraryCrud.Api.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {

            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, AddBookDto>().ReverseMap();
            CreateMap<Book, BookNameDto>().ReverseMap();

            CreateMap<Author,AuthorDto>().ReverseMap();  
            CreateMap<Author, AuthorIdDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Genre, GenreIdDto>().ReverseMap();    
        
        }
    }
}
