using AutoMapper;
using SalesOrderDataWebApp.Shared.Dto;
using SalesOrderDataWebApp.Shared.Models;

namespace SalesOrderDataWebApp.Server.Mappers
{
    public class SalesOrderDataAppMapper : Profile
    {
        public SalesOrderDataAppMapper()
        {
            CreateMap<ElementDto, Element>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<WindowDto, Window>().ReverseMap();
        }
    }
}
