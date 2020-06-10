using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OffRosterAPI.Models
{
    public class OffRosterRequestComment
    {
        [Key]
        public int CommentId { get; set; }
        public int OffRosterRequestId { get; set; }
        public string CommentedBy { get; set; }
        public DateTime CommentedAt { get; set; }
        public string Comment { get; set; }
    }
}
