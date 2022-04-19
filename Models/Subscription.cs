using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Subscription
    {
        public string? SubscriptionId { get; set; }
        public string? SubscriptionName { get; set; }

        public IDictionary<string, string>? Tags { get; set; }
        public int Toto { get; set; }

        public IList<ResourceGroup>? ResourceGroups { get; set; }
    }
}
