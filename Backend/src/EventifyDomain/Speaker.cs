using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventifyDomain
{
    public class Speaker
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<SocialMedia> SocialMedia { get; set; }

        public IEnumerable<SpeakerEvent> SpeakerEvents { get; set; }
    }
}