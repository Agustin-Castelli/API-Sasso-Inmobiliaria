using SassoInmobiliariaAPI.Models.Enums;

namespace SassoInmobiliariaAPI.Services.DTOs
{
    public class PropRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Adress { get; set; }
        public int Price { get; set; }
        public string? Image { get; set; }
        public float Area { get; set; }
        public int Baths { get; set; }
        public int Bedrooms { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public bool IsActive { get; set; }
        public bool IsDistingued { get; set; }
        public bool IsUpToCredit { get; set; }
        public TypeOfPropEnum? TypeOfProp { get; set; }
        public TypeOfOfferEnum? TypeOfOffer { get; set; }
    }
}
