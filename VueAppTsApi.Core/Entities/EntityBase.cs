using VueAppTsApi.Core.Interfaces;

namespace VueAppTsApi.Core.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}