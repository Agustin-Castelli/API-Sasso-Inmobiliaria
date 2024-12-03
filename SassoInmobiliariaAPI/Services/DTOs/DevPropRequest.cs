using SassoInmobiliariaAPI.Models.Entities;

namespace SassoInmobiliariaAPI.Services.DTOs
{
    public class DevPropRequest
    {
        public string? DevelopName { get; set; }
        public string? DevelopDescription { get; set; }
        public string? DevelopAdress { get; set; }
        public string? DevelopImage { get; set; }
        public List<Property>? Properties { get; set; }
    }
}
