namespace PickupGames.Infrastructure.Models
{
    public class BusinessRule
    {
        private string _property;
        private string _rule;

        public BusinessRule(string property, string rule)
        {
            _property = property;
            _rule = rule;
        }

        public string Property
        {
            get { return _property; }
            set { _property = value; }
        }
        
        public string Rule
        {
            get { return _rule; }
            set { _rule = value; }
        }
    }    
}
