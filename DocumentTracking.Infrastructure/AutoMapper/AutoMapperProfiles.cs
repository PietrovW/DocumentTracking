using AutoMapper;
using DocumentTracking.ApplicationCore.Entities;
using DocumentTracking.Infrastructure.Command;

namespace DocumentTracking.Infrastructure.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Invoice,CreateInvoiceCommand> ()
              .ForMember(dest => dest.AttachmentId,opts => opts.MapFrom(src => src.AttachmentId))
              .ForMember(dest => dest.BarCode, opts => opts.MapFrom(src => src.BarCode))
              .ForMember(dest => dest.Date_Received, opts => opts.MapFrom(src => src.DateReceived))
              .ForMember(dest => dest.Items, opts => opts.MapFrom(src => src.InvoiceItems))
              .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
              .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.Type));

            CreateMap<CreateInvoiceCommand, Invoice>()
               .ForMember(dest => dest.Process, opts => opts.Ignore())
               .ForMember(dest => dest.Attachment, opts => opts.Ignore())
               .ForMember(dest => dest.InvoiceItems, opts => opts.MapFrom(src => src.Items))
               .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.Type))
               .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
               .ForMember(dest => dest.Id, opts => opts.Ignore())
               .ForMember(dest => dest.DateReceived, opts => opts.MapFrom(src => src.Date_Received))
               .ForMember(dest => dest.BarCode, opts => opts.MapFrom(src => src.BarCode));
            
            CreateMap<CreateProcessCommand, Process>();
        }
    }
}
