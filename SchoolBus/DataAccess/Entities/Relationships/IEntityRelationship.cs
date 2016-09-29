namespace SchoolBus.DataAccess.Entities.Relationships
{
    public interface IEntityRelationship<TLeftEntity, TRightEntity> : IEntity
        where TLeftEntity : class, IEntity
        where TRightEntity : class, IEntity
    {
        #region Properties

        int LeftEntityId { get; set; }

        TLeftEntity LeftEntity { get; set; }

        int RightEntityId { get; set; }

        TRightEntity RightEntity { get; set; }

        #endregion Properties
    }
}