using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffRosterAPI.Models
{
    public static class MockOffRosterRepository
    {
        public static List<OffRosterRequest> OffRosterRequests = new List<OffRosterRequest>()
            {
            new OffRosterRequest {Id = 1, ThreeLetterCode = "123", StartDate = DateTime.Now.AddDays(-7), EndDate = DateTime.Now.AddMonths(1).Date, IsOpenEnded = false, OffRosterCode = "ORS", RequestingManager = "Dave", IsActioned = true},
            new OffRosterRequest {Id = 2, ThreeLetterCode = "456", StartDate = DateTime.Now.AddDays(5).Date, EndDate = DateTime.Now.AddDays(6).Date, IsOpenEnded = false, OffRosterCode = "LVC", RequestingManager = "Dave", IsActioned = true},
            new OffRosterRequest {Id = 3, ThreeLetterCode = "789", StartDate = DateTime.Now.Date, IsOpenEnded = true, OffRosterCode = "MSG", RequestingManager = "Dave", IsActioned = true},
            new OffRosterRequest {Id = 4, ThreeLetterCode = "101", StartDate = DateTime.Now.AddDays(-5).Date, EndDate = DateTime.Now.AddDays(-2).Date, IsOpenEnded = false, OffRosterCode = "TOD", RequestingManager = "Dave", IsActioned = true},
            new OffRosterRequest {Id = 5, ThreeLetterCode = "112", StartDate = DateTime.Now.AddMonths(1).Date, EndDate = DateTime.Now.AddDays(1).AddMonths(1).Date, IsOpenEnded = false, OffRosterCode = "ORD", RequestingManager = "Dave", IsActioned = false},
            new OffRosterRequest {Id = 5, ThreeLetterCode = "131", StartDate = DateTime.Now.AddMonths(-3).Date, EndDate = DateTime.Now.AddMonths(-3).AddDays(1).AddMonths(1).Date, IsOpenEnded = false, OffRosterCode = "ORD", RequestingManager = "Dave", IsActioned = true}
            };
    }
}
