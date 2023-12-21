using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace WindowsFormsApp11
{

    public partial class Form1 : Form
    {
        private TextBox txtVertexName;
        private TextBox txtEdgeName;
        private TextBox txtEdgeWeight;
        private ListBox listBoxElements;
        private GraphContainer graphContainer;
        private Button btnAddVertex;
        private Button btnAddEdge;
        private Button btnRemove;
        private Label lblVertexName;
        private Label lblEdgeName;
        private Label lblEdgeWeight;
        private Label lblTotalWeight;
        private Label lblVertexCount;
      




        public Form1()
        {
            InitializeComponent();
            graphContainer = new GraphContainer();
            lblTotalWeight = new Label();
            txtVertexName = new TextBox();
            txtEdgeName = new TextBox();
            txtEdgeWeight = new TextBox();
            btnAddVertex = new Button();
            btnAddEdge = new Button();
            btnRemove = new Button();
            listBoxElements = new ListBox();
            lblVertexName = new Label();
            lblEdgeName = new Label();
            lblEdgeWeight = new Label();
            lblVertexCount = new Label();
         



           
            lblVertexName.AutoSize = true;
            lblVertexName.Location = new Point(10, 20);
            lblVertexName.Text = "Ім'я вершини:";
            Controls.Add(lblVertexName);

          
            txtVertexName.Location = new Point(120, 20);
            Controls.Add(txtVertexName);

           
            btnAddVertex.Location = new Point(250, 20);
            btnAddVertex.Text = "Додати вершину";
            btnAddVertex.Click += new EventHandler(btnAddVertex_Click);
            Controls.Add(btnAddVertex);
          
            lblEdgeName.AutoSize = true;
            lblEdgeName.Location = new Point(10, 60);
            lblEdgeName.Text = "Ім'я дуги:";
            Controls.Add(lblEdgeName);

           
            txtEdgeName.Location = new Point(120, 60);
            Controls.Add(txtEdgeName);

            lblEdgeWeight.AutoSize = true;
            lblEdgeWeight.Location = new Point(250, 60); 
            lblEdgeWeight.Text = "Вага дуги:";
            Controls.Add(lblEdgeWeight);

            
            txtEdgeWeight.Location = new Point(370, 60); 
            Controls.Add(txtEdgeWeight);

           
            btnAddEdge.Location = new Point(500, 60); 
            btnAddEdge.Text = "Додати дугу";
            btnAddEdge.Click += new EventHandler(btnAddEdge_Click);
            Controls.Add(btnAddEdge);

            
            btnRemove.Location = new Point(370, 100);
            btnRemove.Text = "Видалити елемент";
            btnRemove.Click += new EventHandler(btnRemove_Click);
            Controls.Add(btnRemove);

         
            listBoxElements.Location = new Point(10, 100);
            listBoxElements.Size = new Size(300, 150);
            Controls.Add(listBoxElements);

            graphContainer.OnElementAdded += GraphContainer_OnElementAdded;
            graphContainer.OnElementRemoved += GraphContainer_OnElementRemoved;

            lblTotalWeight.AutoSize = true;
            lblTotalWeight.Location = new Point(10, 260);
            lblTotalWeight.Text = "Загальна вага: ";
            Controls.Add(lblTotalWeight);

           
            lblVertexCount.AutoSize = true;
            lblVertexCount.Location = new Point(10, 290);
            lblVertexCount.Text = "Кількість вершин: ";
            Controls.Add(lblVertexCount);
        }

        private void btnAddVertex_Click(object sender, EventArgs e)
        {
            string vertexName = txtVertexName.Text;
            Vertex vertex = new Vertex(vertexName);
            graphContainer.AddElement(vertex);

            
            txtVertexName.Clear();

           
            UpdateVertexCount();
            UpdateTotalWeight();
        }

        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            string edgeName = txtEdgeName.Text;
            int edgeWeight;

            if (int.TryParse(txtEdgeWeight.Text, out edgeWeight))
            {
                Edge edge = new Edge(edgeName, edgeWeight);
                graphContainer.AddElement(edge);

              
                txtEdgeName.Clear();
                txtEdgeWeight.Clear();

                
                UpdateVertexCount();
                UpdateTotalWeight();
            }
            else
            {
                MessageBox.Show("Введіть коректну вагу дуги (ціле число).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GraphContainer_OnElementAdded(GraphElement element)
        {
           
            if (element is Vertex vertex)
            {
                listBoxElements.Items.Add($"Додано вершину: {vertex.Name}");
            }
            else if (element is Edge edge)
            {
                listBoxElements.Items.Add($"Додано дугу: {edge.Name}, Вага: {edge.Weight}");
            }

            UpdateVertexCount();
            UpdateTotalWeight();
        }



        private void btnDisplay_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBoxElements.SelectedItem != null)
            {
                
                var selectedElement = listBoxElements.SelectedItem as string;

                
                var elements = graphContainer.GetElements();
                foreach (var element in elements)
                {
                    if (element.ToString() == selectedElement)
                    {
                        graphContainer.RemoveElement(element);
                        

                        break; 
                    }
                }

               
                UpdateListBox();

             
                UpdateVertexCount();
                UpdateTotalWeight();
            }
        }











        private void GraphContainer_OnElementRemoved(GraphElement element)
        {
           
            if (element is Vertex)
            {
                UpdateVertexCount();
            }
            else if (element is Edge)
            {
                UpdateTotalWeight();
            }
        }

        private void UpdateListBox()
        {
            listBoxElements.Items.Clear();

           
            var elements = graphContainer.GetElements();
            foreach (var element in elements)
            {
                listBoxElements.Items.Add(element.ToString());
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
         
            graphContainer.OnElementAdded += GraphContainer_OnElementAdded;
            graphContainer.OnElementRemoved += GraphContainer_OnElementRemoved;

           
            UpdateVertexCount();
           
            UpdateTotalWeight();
        }

     
        private void UpdateVertexCount()
        {
           
            lblVertexCount.Text = $"Кількість вершин: {graphContainer.GetVertexCount()}";
        }

        private void UpdateTotalWeight()
        {
           
            lblTotalWeight.Text = $"Загальна вага: {graphContainer.CalculateTotalWeight()}";
        }



    }


}

