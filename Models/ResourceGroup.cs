using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("ResourceGroup")]
    public class ResourceGroup
    {
        [Key]
        public string ResourceGroupId { get; set; }
        public string ResourceGroupName { get; set; }

        public Dictionary<string, string> Tags { get; set; }

        public List
    }
}