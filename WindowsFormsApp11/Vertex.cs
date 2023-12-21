using System;

namespace WindowsFormsApp11
{
   

    // Похідний клас Вершина
    public class Vertex : GraphElement
    {
        public Vertex(string name) : base(name) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Вершина: {Name}");
        }
    }

  
}

