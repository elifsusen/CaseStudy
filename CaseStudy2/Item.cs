using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy2
{
    public class Item
    {
        public string Description { get; set; }
        public BoundingPoly BoundingPoly { get; set; }
    }

    public class BoundingPoly
    {
        public BoundingPoly()
        {
            Vertices = new List<Vertice>();
        }
        public List<Vertice> Vertices { get; set; }
    }

    public class Vertice
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
