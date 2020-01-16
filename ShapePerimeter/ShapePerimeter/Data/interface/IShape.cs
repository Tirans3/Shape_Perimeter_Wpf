using ShapePerimeter.Data.Helper;
using System;

namespace ShapePerimeter
{
    public interface IShape:ICloneable
    {      
        ShapeTypeEnum Type { get; }
        double GetPeremiter();
        bool IsValid { get; }

        double X { get; set; }
        double Y { get; set; }
    }
}
