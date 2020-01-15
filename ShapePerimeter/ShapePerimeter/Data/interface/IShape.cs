using ShapePerimeter.Data.Helper;

namespace ShapePerimeter
{
    public interface IShape
    {      
        ShapeTypeEnum Type { get; }
        double GetPeremiter();
        bool IsValid { get; }
    }
}
