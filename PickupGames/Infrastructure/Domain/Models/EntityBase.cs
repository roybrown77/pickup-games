using System.Collections.Generic;

namespace PickupGames.Infrastructure.Domain.Models
{
    public abstract class EntityBase<TId>
    {
        public TId Id { get; set; }

        private readonly List<BusinessRule.BusinessRule> _brokenRules = new List<BusinessRule.BusinessRule>();
        protected abstract void Validate();

        public IEnumerable<BusinessRule.BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected void AddBrokenRule(BusinessRule.BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        public override bool Equals(object entity)
        {
            return entity != null
            && entity is EntityBase<TId>
            && this == (EntityBase<TId>)entity;
        }
        
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator == (EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
            return true;
            }
            if ((object)entity1 == null || (object)entity2 == null)
            {
            return false;
            }
            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
            return true;
            }
            return false;
        }

        public static bool operator !=(EntityBase<TId> entity1,EntityBase<TId> entity2)
        {
            return (!(entity1 == entity2));
        }
    }
}