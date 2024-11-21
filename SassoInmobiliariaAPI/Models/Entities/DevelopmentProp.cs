namespace SassoInmobiliariaAPI.Models.Entities
{
    public class DevelopmentProp
    {
        public int Id { get; set; }
        public string? DelevopName { get; set; }
        public string? DevelopDescription { get; set; }
        public string? DevelopAdress { get; set; }
        public string? DevelopImage { get; set; }
        public List<Property>? Properties { get; set; }
    }
}
