using AutoMapper;

namespace SchoolBusWeb.Tests.Models.Mappings
{
    public class TestModelMapperProfile : Profile
    {
        #region Constructors

        public TestModelMapperProfile()
        {
            CreateMap<SchoolBusWeb.Models.ModelProperty<string>, string>()
                .ConvertUsing(src => src.GenericValue);

            CreateMap<string, SchoolBusWeb.Models.ModelProperty<string>>()
                .ConvertUsing(src => new SchoolBusWeb.Models.ModelProperty<string>(src));

            CreateMap<SchoolBus.DataAccess.Entities.User, SchoolBusWeb.Models.User>();

            CreateMap<SchoolBusWeb.Models.User, SchoolBus.DataAccess.Entities.User>();

            CreateMap<TestEntity, TestModel>();

            CreateMap<TestModel, TestEntity>();
        }

        #endregion Constructors
    }
}