using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalc.ViewModel
{
    public class AddFunctionsViewModel
    {
        private string display;

        public string Display
        {
            get { return display; }
            set { display = value; }
        }
        // Buttons presed
        public void Button(string button)
        {
            display += button;
        }
    }
}
