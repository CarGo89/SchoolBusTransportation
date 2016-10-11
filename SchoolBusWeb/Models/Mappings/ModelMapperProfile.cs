using System;
using AutoMapper;

namespace SchoolBusWeb.Models.Mappings
{
    internal class ModelMapperProfile : Profile
    {
        #region Constructors

        public ModelMapperProfile()
        {
            CreateMap<ModelProperty<string>, string>()
                .ConvertUsing(src => src == null ? string.Empty : src.Value);

            CreateMap<string, ModelProperty<string>>()
                .ConvertUsing(src => new ModelProperty<string>(src));

            CreateMap<string, DateTime?>()
               .ConvertUsing(src =>
               {
                   DateTime dateValue;

                   if (DateTime.TryParse(src, out dateValue))
                   {
                       return dateValue;
                   }

                   return null;
               });

            CreateMap<DateTime?, string>()
                .ConvertUsing(src => src.HasValue ? src.Value.ToShortDateString() : string.Empty);

            CreateMap<SchoolBus.DataAccess.Entities.User, User>();
            CreateMap<User, SchoolBus.DataAccess.Entities.User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.DeactivatedAt, opt => opt.Ignore());

            CreateMap<SchoolBus.DataAccess.Entities.Driver, Driver>();
            CreateMap<Driver, SchoolBus.DataAccess.Entities.Driver>();
        }

        #endregion Constructors
    }
}