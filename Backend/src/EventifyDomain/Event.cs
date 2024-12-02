using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventifyDomain
{
    public class Event
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Location { get; set; }
        public DateTime? Date { get; set; }
        public int QtyPeople { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Batch> Batches { get; set; }
        public IEnumerable<SocialMedia> SocialMedia { get; set; }

        public IEnumerable<SpeakerEvent> SpeakerEvents { get; set; }
    }
}