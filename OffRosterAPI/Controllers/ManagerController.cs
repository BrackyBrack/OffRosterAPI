using Microsoft.AspNetCore.Mvc;
using OffRosterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OffRosterAPI.Controllers
{
    [Route("api/[controller]")]
    public class ManagerController : Controller
    {
        private readonly IOffRosterRequestRepository _offRosterRequestRepository;

        public ManagerController(IOffRosterRequestRepository offRosterRequestRepository)
        {
            _offRosterRequestRepository = offRosterRequestRepository;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<OffRosterRequest> Get()
        {
            return _offRosterRequestRepository.OffRosterRequests;
        }
        [HttpGet("ToAction", Name = "ToAction")]
        public IEnumerable<OffRosterRequest> GetToAction()
        {
            return _offRosterRequestRepository.OffRosterRequests.Where(n => n.IsActioned == false);
        }

        [HttpGet("BetweenDates", Name ="BetweenDates")]
        public IEnumerable<OffRosterRequest> GetByDate([FromQuery]string start, [FromQuery]string end)
        {
            DateTime startDate = DateTime.Parse(start);
            DateTime endDate = DateTime.Parse(end);

            List<OffRosterRequest> endsDuring = _offRosterRequestRepository.OffRosterRequests.Where(n => n.EndDate >= startDate && n.StartDate <= endDate).ToList();
            List<OffRosterRequest> startsDuring = _offRosterRequestRepository.OffRosterRequests.Where(n => n.StartDate >= startDate && n.StartDate <= endDate).ToList();
            List<OffRosterRequest> openEnded = _offRosterRequestRepository.OffRosterRequests.Where(n => n.IsOpenEnded == true && n.StartDate > endDate).ToList();

            List<OffRosterRequest> result = new List<OffRosterRequest>();
            result.AddRange(endsDuring);
            result.AddRange(startsDuring);
            result.AddRange(openEnded);

            return result.Distinct();
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public OffRosterRequest Get(int id)
        {
            return _offRosterRequestRepository.GetOffRosterRequestById(id).Result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] OffRosterRequest offRosterRequest)
        {
            if (string.IsNullOrEmpty(offRosterRequest.ThreeLetterCode) == false)
            {
                _offRosterRequestRepository.AddNewRequest(offRosterRequest);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]bool value)
        {
            _offRosterRequestRepository.UpdateActioned(id, value);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}