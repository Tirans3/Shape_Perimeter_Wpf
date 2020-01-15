using ShapePerimeter.Data.Helper;
using System.ComponentModel;

namespace ShapePerimeter.Data.Model
{
    public class RectangleModel : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public ShapeTypeEnum Type => ShapeTypeEnum.Rectangle;

        public bool IsValid => Height>0 && Width>0;

        public RectangleModel()
        {
            
        }
        public double GetPeremiter()
        {
            return (Height + Width) * 2;
        }
    }
}
