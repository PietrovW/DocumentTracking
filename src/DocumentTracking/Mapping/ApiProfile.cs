using AutoMapper;
using DocumentTracking.Api.Models;
using DocumentTracking.Infrastructure.Command;
using DocumentTracking.Infrastructure.Queries;

namespace DocumentTracking.Api.Mapping
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<CreateProcessCommand, ProcessModel>().ReverseMap();
            CreateMap<CreateInvoiceCommand, InvoiceModel>().ReverseMap();
            CreateMap<LoginQuerie, LoginModel>().ReverseMap();
        }
    }
}
