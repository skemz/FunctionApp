using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class ResourceGroup
    {
        public string? ResourceGroupName { get; set; }

        public Dictionary<string, string>? Tags { get; set; }
    }
}