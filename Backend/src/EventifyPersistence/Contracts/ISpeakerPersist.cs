using System;
using System.Threading.Tasks;
using EventifyDomain;

namespace EventifyPersistence.Contracts
{
    public interface ISpeakerPersist
    {
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents);
        Task<Speaker[]> GetAllSpeakersByNameAsync(string Name, bool includeEvents);
        Task<Speaker> GetSpeakerByIdAsync(int SpeakerId, bool includeEvents);
    }
}
