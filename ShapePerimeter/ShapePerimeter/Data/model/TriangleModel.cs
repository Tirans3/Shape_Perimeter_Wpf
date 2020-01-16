using ShapePerimeter.Data.Helper;
using System;
using System.Windows;
using System.Windows.Media;

namespace ShapePerimeter.Data.Model
{
    public class TriangleModel : IShape
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }

        public double X2 { get; set; }
        public double Y2 { get; set; }

        public double X3 { get; set; }
        public double Y3 { get; set; }

        
        public PointCollection Points { get { return new PointCollection(new[] { new Point(X1,Y1), new Point(X2,Y2), new Point(X3,Y3)}); } }
       
        public ShapeTypeEnum Type { get { return ShapeTypeEnum.Triangle; } }

        public bool IsValid => true;

        public double X { get; set; }
        public double Y { get; set; }

        public TriangleModel()
        {
            
        }
        
        public double GetPeremiter()
        {
            return Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2)) + Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2)) + Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - Y3, 2));
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
