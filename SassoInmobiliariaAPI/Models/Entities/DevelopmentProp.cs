using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SassoInmobiliariaAPI.Models.Enums;

namespace SassoInmobiliariaAPI.Models.Entities
{
    public class DevelopmentProp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? DevelopName { get; set; }
        public string? DevelopDescription { get; set; }
        public string? DevelopAdress { get; set; }
        public string? DevelopImage { get; set; }
        public bool IsActive { get; set; }
        public StateOfDevelopEnum StateOfDevelop { get; set; }
        public List<Property>? Properties { get; set; } = new List<Property>();
    }
}
