using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OffRosterAPI.Models;

namespace OffRosterAPI.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly IOffRosterRequestRepository _offRosterRequestRepository;

        public CommentController(IOffRosterRequestRepository offRosterRequestRepository)
        {
            _offRosterRequestRepository = offRosterRequestRepository;
        }

        [HttpPost]
        public void Post([FromBody] OffRosterRequestComment comment)
        {
            if (comment.OffRosterRequestId > 0)
            {
                comment.CommentedAt = DateTime.Now;
                comment.CommentedBy = "Dave";

                _offRosterRequestRepository.AddNewComment(comment);
            }
        }
    }
}