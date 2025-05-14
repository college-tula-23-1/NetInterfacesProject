using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLinkWelcomeProject
{
    class Airflight
    {
        public string Name { set; get; } = null!;
        public string? Departure { set; get; }
        public string? Arrival { set; get; }
        public int Price { set; get; }

        public override string ToString()
        {
            return $"Flight name: {Name} \t| From: {Departure} \t| To: {Arrival} \t| [{Price}]";
        }
    }
}
