using System;
using System.Collections.Generic;

namespace lab5
{
    
    public record Shape(string Name, Func<double> Area);

    public static class FactoryPattern
    {
        
        public static Dictionary<string, Func<Shape>> GetShapeFactory()
        {
            return new Dictionary<string, Func<Shape>>
            {
                ["circle"]   = () => new Shape("Circle", () => Math.PI * 5 * 5),
                ["square"]   = () => new Shape("Square", () => 4.0 * 4.0),
                ["triangle"] = () => new Shape("Triangle", () => 0.5 * 6.0 * 4.0)
            };
        }
    }
}
