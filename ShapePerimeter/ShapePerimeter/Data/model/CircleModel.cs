using ShapePerimeter.Data.Helper;
using System;

namespace ShapePerimeter.Data.Model
{
    public class CircleModel : IShape
    {
        public double Radius { get; set; }
        public ShapeTypeEnum Type => ShapeTypeEnum.Circle;

        public bool IsValid => Radius>0;

        public double X { get; set; }
        public double Y { get; set; }

        public double GetPeremiter()
        {
            return 2 * Math.PI * Radius;
        }

        public object Clone()
        {
            return new CircleModel {Radius = Radius };
        }
    }
}
