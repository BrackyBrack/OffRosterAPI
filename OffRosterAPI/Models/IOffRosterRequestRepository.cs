using System.Collections.Generic;
using System.Threading.Tasks;

namespace OffRosterAPI.Models
{
    public interface IOffRosterRequestRepository
    {
        IEnumerable<OffRosterRequest> OffRosterRequests { get; }

        Task AddNewRequest(OffRosterRequest offRosterRequest);

        Task UpdateActioned(int id, bool isActioned);

        Task<OffRosterRequest> GetOffRosterRequestById(int id);
        void AddNewComment(OffRosterRequestComment comment);
    }
}