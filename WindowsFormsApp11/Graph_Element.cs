using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp11
{
    public abstract class GraphElement
    {
        public string Name { get; set; }

        protected GraphElement(string name)
        {
            Name = name;
        }

        public abstract void DisplayInfo();
    }

}
