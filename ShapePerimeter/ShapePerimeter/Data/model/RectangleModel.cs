using ShapePerimeter.Data.Helper;

namespace ShapePerimeter.Data.Model
{
    public class RectangleModel : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public ShapeTypeEnum Type => ShapeTypeEnum.Rectangle;

        public bool IsValid => Height > 0 && Width > 0;

        public double X { get; set; }
        public double Y { get; set; }

        public double GetPeremiter()
        {
            return (Height + Width) * 2;
        }

        public object Clone()
        {
            return new RectangleModel { Height = Height, Width = Width };
        }
    }
}
