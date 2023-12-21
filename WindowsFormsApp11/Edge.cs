using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp11
{
    // Похідний клас Дуга
    public class Edge : GraphElement
    {
        public int Weight { get; }

        public Edge(string name, int weight) : base(name)
        {
            Weight = weight;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Дуга: {Name}, Вага: {Weight}");
        }
    }
}
