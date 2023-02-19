using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CaseStudy2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            using (StreamReader r = new StreamReader("response.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Item>>(json);
            }
            items.Remove(items[0]);

            Console.WriteLine("line |  text ");
            foreach (var item in ExtractParagraphs(items))
            {
                Console.WriteLine($"{item.Line}    {item.Text}");
            }
        }


        public static List<TextLine> ExtractParagraphs(List<Item> textAnnotations)
        {

            var textBoxes = new List<TextBox>();

            foreach (var item in textAnnotations)
            {
                var poly_range = GetYRange(item.BoundingPoly);
                var t_x = GetX(item.BoundingPoly);
                var t_min = poly_range.Min();
                var t_max = poly_range.Max();
                textBoxes.Add(new TextBox
                {
                    Min_y = t_min,
                    Max_y = t_max,
                    X = t_x,
                    Description = item.Description
                });
            }

            var prevItem = new TextBox();
            int count = 0;
            List<TextLine> texts = new List<TextLine>();

            foreach (var item in textBoxes)
            {
                //en yakın y koordinatlı öğeyi bul.
                var closest = texts.Any() ? texts.Aggregate((x, y) => Math.Abs(x.First_y - item.Min_y) < Math.Abs(y.First_y - item.Min_y) ? x : y)
                                              : new TextLine();
                var currentText = texts.FirstOrDefault(x => x.Line == closest.Line);

                if (prevItem.Max_y <= item.Min_y || prevItem.X > item.X)
                {
                    
                    if (closest.Last_x != 0 && closest.Last_x < item.X)
                    {
                        currentText.Text = $"{texts[closest.Line - 1].Text} {item.Description}";
                        currentText.Last_x = item.X;

                    }
                    else
                    {
                        count++;
                        texts.Add(new TextLine { Line = count, Text = item.Description, First_y = item.Min_y, Last_x = item.X });
                    }

                }
                else
                {
                    currentText.Text = $"{texts[closest.Line - 1].Text} {item.Description}";
                    currentText.Last_x = item.X;
                }

                prevItem = item;
            }

            return texts;

        }

        private static List<int> GetYRange(BoundingPoly poly)
        {
            var y_list = new List<int>();
            foreach (var v in poly.Vertices)
            {
                if (!y_list.Contains(v.Y))
                    y_list.Add(v.Y);
            }

            return y_list;
        }

        private static int GetX(BoundingPoly poly)
        {
            return poly.Vertices[0].X;
        }

        public class TextBox
        {
            public int Min_y { get; set; }
            public int Max_y { get; set; }
            public int X { get; set; }
            public string Description { get; set; }

        }

        public class TextLine
        {
            public int Line { get; set; }
            public string Text { get; set; }
            public int First_y { get; set; }
            public int Last_x { get; set; }
        }
    }
}
