using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventifyDomain
{
    public class Batch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Quantity { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}