using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Resource
    {
        public string ResourceId { get; set; }
        public string ResourceName { get; set; }
        public Dictionary<string, string> Tags { get; set; }
        public ResourceType ResourceType { get; set; }
    }
}
