using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace propertyDetailer.API.Context
{
    public class PropertyDetails
    {
        [Key]
        public int Id { get; set; }
        public Address Address { get; set; }
        public Physical Physical { get; set; }
        public Financial Financial { get; set; }
    }
}
