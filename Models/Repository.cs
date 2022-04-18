using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Repository
    {
        public string Id { get; set; }
        public string Name { get; set; }
        Dictionary<string, object> Tags { get; set; }
    }
}
