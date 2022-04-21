using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Entities
{
    public class Unit
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int Coordinator { get; set; }

        public override string ToString()
        {
            return Code + " " + Title;
        }

    }

    
}
