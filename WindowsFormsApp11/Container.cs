using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp11
{
    // Клас контейнер
    public class GraphContainer
    {
        private List<GraphElement> elements;

        public GraphContainer()
        {
            elements = new List<GraphElement>();
        }

        public void AddElement(GraphElement element)
        {
            elements.Add(element);
            OnElementAdded?.Invoke(element);
        }

        public void RemoveElement(GraphElement element)
        {
            elements.Remove(element);
            OnElementRemoved?.Invoke(element);
        }

        public List<GraphElement> GetElements()
        {
            return elements;
        }

        public int CalculateTotalWeight()
        {
            int totalWeight = 0;
            foreach (var element in elements)
            {
                if (element is Edge edge)
                {
                    totalWeight += edge.Weight;
                }
            }
            return totalWeight;
        }


        public int GetVertexCount()
        {
            int vertexCount = 0;
            foreach (var element in elements)
            {
                if (element is Vertex)
                {
                    vertexCount++;
                }
               
                
            }
            return vertexCount;
        }


       
        public event Action<GraphElement> OnElementAdded;
        public event Action<GraphElement> OnElementRemoved;
    }

}
