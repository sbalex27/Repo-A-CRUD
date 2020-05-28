using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp_Alpha_2
{
    class Purchase
    {
        public string Invoice { get; set; }
        public string Provider { get; set; }
        public bool Valid { get; private set; }
    }
}
