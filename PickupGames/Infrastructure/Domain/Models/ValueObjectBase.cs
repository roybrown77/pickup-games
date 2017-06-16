using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using PickupGames.Infrastructure.Exceptions;

namespace PickupGames.Infrastructure.Domain.Models
{
    public abstract class ValueObjectBase
    {
        private readonly List<BusinessRule.BusinessRule> _brokenRules = new List<BusinessRule.BusinessRule>();        
        protected abstract void Validate();
        
        public void ThrowExceptionIfInvalid()
        {
            _brokenRules.Clear();
            Validate();

            if (_brokenRules.Any())
            {
                var brokenRules = new StringBuilder();

                foreach (BusinessRule.BusinessRule businessRule in _brokenRules)
                {
                    brokenRules.AppendLine(businessRule.Rule);
                }

                throw new ApplicationLayerException(HttpStatusCode.BadRequest, brokenRules.ToString());
            }
        }
        protected void AddBrokenRule(BusinessRule.BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }
    }
}
