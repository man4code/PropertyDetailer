using System.ComponentModel.DataAnnotations;

namespace propertyDetailer.API.Context
{
    public class Physical
    {
        [Key]
        public int Id { get; set; }
        public int YearBuilt { get; set; }
    }
}