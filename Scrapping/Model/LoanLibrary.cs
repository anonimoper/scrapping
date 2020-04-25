using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrapping
{
    public class LoanLibrary
    {        
        public string Name { get; set; }
        public List<LoanData> LoanData { get; set; }

        public LoanLibrary()
        {
            this.LoanData = new List<LoanData>();
        }
    }
}
