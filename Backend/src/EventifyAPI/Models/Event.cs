using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventify.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Theme { get; set; }
        public int QtyPeople { get; set; }
        public string Batch { get; set; }
        public string ImageURL { get; set; }
    }
}