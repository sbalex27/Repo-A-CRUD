using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp_Alpha_2
{
    class Sale
    {
        public int ID { get; set; }
        public double Amount { get; set; }
        public string Notes { get; set; }
        public DateTime RegistrationTime { get; private set; }
        public string Seller { get; private set; }
    }
}
