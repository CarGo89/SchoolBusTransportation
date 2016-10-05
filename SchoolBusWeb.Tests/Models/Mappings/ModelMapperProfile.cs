using AutoMapper;

namespace SchoolBusWeb.Tests.Models.Mappings
{
    public class ModelMapperProfile : Profile
    {
        #region Constructors

        public ModelMapperProfile()
        {
            CreateMap<SchoolBus.DataAccess.Entities.User, SchoolBusWeb.Models.User>();

            CreateMap<SchoolBusWeb.Models.User, SchoolBus.DataAccess.Entities.User>();

            CreateMap<TestEntity, TestModel>();

            CreateMap<TestModel, TestEntity>();
        }

        #endregion Constructors
    }
}