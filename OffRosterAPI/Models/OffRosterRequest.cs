using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OffRosterAPI.Models
{
    public class OffRosterRequest
    {
        [Key]
        public int Id { get; set; }

        public string ThreeLetterCode { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsOpenEnded { get; set; }

        public string OffRosterCode { get; set; }

        public string RequestingManager { get; set; }

        public bool IsActioned { get; set; }

        public List<OffRosterRequestComment> Comments { get; set; }

        public OffRosterRequest()
        {

        }

        public override bool Equals(object obj)
        {
            var toCompare = obj as OffRosterRequest;
            return this.Id == toCompare.Id;
        }
    }
}


