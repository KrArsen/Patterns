using System;
using System.Collections.Generic;

namespace lab5
{
    /// <summary>
    /// Патерн "Фабричний метод" (Factory Method) у функціональному стилі.
    /// Замість створення ієрархії класів Creator/ConcreteCreator та Shape/ConcreteShape,
    /// ми використовуємо простий запис (record) Shape, що містить назву та функцію для
    /// обчислення площі. Фабрика ж представлена як словник Dictionary&lt;string, Func&lt;Shape&gt;&gt;.
    /// </summary>
    
    // Фігура представляє собою простий record з назвою та функціональним делегатом для обчислення площі
    public record Shape(string Name, Func<double> Area);

    public static class FactoryPattern
    {
        /// <summary>
        /// Повертає словник фабричних методів для створення фігур.
        /// </summary>
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
