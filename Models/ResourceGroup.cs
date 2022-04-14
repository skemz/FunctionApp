namespace Models
{
    public class ResourceGroup
    {
        public string ResourceGroupId { get; set; }
        public string ResourceGroupName { get; set; }

        public Dictionary<string, string> Tags { get; set; }
    }
}