using System.ComponentModel.DataAnnotations;

namespace propertyDetailer.API.Context
{
    public class Financial
    {
        [Key]
        public int Id { get; set; }
        public decimal ListPrice { get; set; }
        public decimal MonthlyRent { get; set; }
    }
}