using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffRosterAPI.Models
{
    public class OffRosterRequestRepository : IOffRosterRequestRepository
    {
        private readonly AppDbContext _appDbContext;

        public OffRosterRequestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<OffRosterRequest> OffRosterRequests
        {
            get
            {
                return _appDbContext.OffRosterRequests.Include(n => n.Comments).Where(n => string.IsNullOrEmpty(n.ThreeLetterCode) == false);
            }
        }

        public async Task UpdateActioned(int id, bool isActioned)
        {
            OffRosterRequest offRoster = OffRosterRequests.FirstOrDefault(n => n.Id == id);

            offRoster.IsActioned = isActioned;

            _appDbContext.Update(offRoster);
            _appDbContext.SaveChanges();
        }
        public async Task AddNewRequest(OffRosterRequest offRosterRequest)
        {
            _appDbContext.Add<OffRosterRequest>(offRosterRequest);
            _appDbContext.SaveChanges();
        }

        public async Task<OffRosterRequest> GetOffRosterRequestById(int id)
        {
            OffRosterRequest request = _appDbContext.OffRosterRequests.Include(n => n.Comments).FirstOrDefault(n => n.Id == id);

            return request;
        }

        public void AddNewComment(OffRosterRequestComment comment)
        {
            _appDbContext.Add(comment);

            _appDbContext.SaveChanges();
        }
    }
}
