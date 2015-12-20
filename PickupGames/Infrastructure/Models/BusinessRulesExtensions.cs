using System.Collections.Generic;
using System.Linq;
using PickupGames.Infrastructure.Exceptions;

namespace PickupGames.Infrastructure.Models
{
    public static class BusinessRuleExtensions
    {
        public static IEnumerable<Error> ConvertToErrors(this IEnumerable<BusinessRule> businessRules)
        {
            return businessRules.Select(brokenRule => new Error
            {
                Id = brokenRule.Property,
                Message = brokenRule.Rule
            });
        }        
    }    
}
