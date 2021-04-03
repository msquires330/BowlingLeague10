using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague10.Models.ViewModels
{
    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        // Calculate the Number of pages (you need to make at least one of the items a non-integer so when the result isn't a whole number you don't loose data. 
        public int NumPages => (int) (Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage));
    }
}
