using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÄlytaloWEB.Models
{
    public class SaunaLämpöModel
    {

        public bool Switched { get; set; }
        public void SaunaOn (int tila)
        {
            if (tila == 0)
            {
                Switched = false;
            }
            else
            {
                Switched = true;
            }
        }
    }
}
