using AutoMapper;
using BookLibrary.BLL.Model;
using BookLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BLL.Utils
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            //   BookDTO <= Book
            CreateMap<Book, BookDTO>()
        //    Author = item.Author.Name,
                .ForMember(x=>x.Author, opt=>opt.MapFrom(x=>x.Author.Name))
                .ForMember(x=>x.Genre, opt=>opt.MapFrom(x=>x.Genre.Name));

            CreateMap<BookDTO, Book>()
                // Author = new Author
                .ForMember(x => x.Author, opt => opt.MapFrom(x => new Author { Name = x.Author }))
                .ForMember(x=>x.Genre, opt=>opt.MapFrom(x=> new Genre { Name = x.Genre}));
        }
    }
}
