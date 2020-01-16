using ShapePerimeter.Data.Helper;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

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


        public PointCollection Points { get { return new PointCollection(new[] { new Point(X1, Y1), new Point(X2, Y2), new Point(X3, Y3) }); } }

        public ShapeTypeEnum Type { get { return ShapeTypeEnum.Triangle; } }

        public bool IsValid => !((X1==X2==true)&(X1==X3)||(Y1==Y2==true)&(Y1==Y3));

        public double X { get; set; }
        public double Y { get; set; }

        
        public double GetPeremiter()
        {
            return Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2)) + Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2)) + Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - Y3, 2));
        }

        public object Clone()
        {
            return  new TriangleModel {X1=X1,Y1=Y1,X2=X2,X3=X3,Y2=Y2,Y3=Y3 };
        }
    }
}
