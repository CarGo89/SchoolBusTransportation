using AutoMapper;

namespace SchoolBusWeb.Tests.Models.Mappings
{
    public class TestModelMapperProfile : Profile
    {
        #region Constructors

        public TestModelMapperProfile()
        {
            CreateMap<SchoolBusWeb.Models.ModelProperty<string>, string>()
                .ConvertUsing(src => src.Value);

            CreateMap<string, SchoolBusWeb.Models.ModelProperty<string>>()
                .ConvertUsing(src => new SchoolBusWeb.Models.ModelProperty<string>(src));

            CreateMap<SchoolBus.DataAccess.Entities.User, SchoolBusWeb.Models.User>();
            CreateMap<SchoolBusWeb.Models.User, SchoolBus.DataAccess.Entities.User>();

            CreateMap<TestEntity, TestModel>();

            CreateMap<TestModel, TestEntity>();

            CreateMap<SchoolBus.DataAccess.Entities.Driver, SchoolBusWeb.Models.Driver>();
            CreateMap<SchoolBusWeb.Models.Driver, SchoolBus.DataAccess.Entities.Driver>();

            CreateMap<SchoolBus.DataAccess.Entities.Tutor, SchoolBusWeb.Models.Tutor>();
            CreateMap<SchoolBusWeb.Models.Tutor, SchoolBus.DataAccess.Entities.Tutor>();
        }

        #endregion Constructors
    }
}