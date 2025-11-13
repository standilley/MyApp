
using MyApp.Application.DTOs;
using MyApp.Domain.Entities;
using AutoMapper;

namespace MyApp.Application.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
