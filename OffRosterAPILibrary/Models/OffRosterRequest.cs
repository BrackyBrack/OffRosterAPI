using System;
using System.Collections.Generic;
using System.Text;

namespace OffRosterAPILibrary.Models
{
    public class OffRosterRequest
    {
        public int Id { get; set; }

        public string ThreeLetterCode { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsOpenEnded { get; set; }

        public string OffRosterCode { get; set; }

        public string RequestingManager { get; set; }

        public bool IsActioned { get; set; }
    }


}


