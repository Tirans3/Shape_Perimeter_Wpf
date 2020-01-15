using ShapePerimeter.Data.Helper;
using System;

namespace ShapePerimeter.Data.Model
{
    public class CircleModel : IShape
    {
        public double Radius { get; set; }
        public ShapeTypeEnum Type => ShapeTypeEnum.Circle;

        public bool IsValid => Radius>0;

        public CircleModel()
        {
        }
        public double GetPeremiter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
