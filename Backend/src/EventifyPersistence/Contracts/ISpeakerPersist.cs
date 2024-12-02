using System;
using System.Threading.Tasks;
using EventifyDomain;

namespace EventifyPersistence.Contracts
{
    public interface ISpeakerPersist
    {
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false);
        Task<Speaker[]> GetAllSpeakersByNameAsync(string Name, bool includeEvents = false);
        Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false);
    }
}
