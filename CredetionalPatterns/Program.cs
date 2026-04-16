using System;
using CreationalPatterns.Singleton;
using CreationalPatterns.FactoryMethod;
using CreationalPatterns.AbstractFactory;
using CreationalPatterns.Builder;
using CreationalPatterns.Prototype;
using CreationalPatterns.ObjectPool;

// Add new structural pattern namespaces
using StructuralPatterns.Adapter;
using StructuralPatterns.Bridge;
using StructuralPatterns.Composite;
using StructuralPatterns.Decorator;
using StructuralPatterns.Facade;
using StructuralPatterns.Flyweight;
using StructuralPatterns.Proxy;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Console.WriteLine("\n--- CREATIONAL PATTERNS ---");
        Singleton.Instance.Show();
        
        Creator creator = new ConcreteCreator();
        var product = creator.CreateProduct();
        product.Use();
        
        IFactory factory = new WindowsFactory();
        var button = factory.CreateButton();
        button.Paint();
        
        var builder = new Builder();
        builder.BuildPartA();
        builder.BuildPartB();
        Console.WriteLine(builder.GetResult());
        
        var p1 = new Prototype { Value = 5 };
        var p2 = p1.Clone();
        Console.WriteLine("Prototype: " + p2.Value);
        
        var pool = new ObjectPool();
        var obj = pool.GetObject();
        Console.WriteLine("ObjectPool: " + obj);

        Console.WriteLine("\n--- STRUCTURAL PATTERNS ---");
        AdapterDemo.Show();
        BridgeDemo.Show();
        CompositeDemo.Show();
        DecoratorDemo.Show();
        FacadeDemo.Show();
        FlyweightDemo.Show();
        ProxyDemo.Show();
        Console.WriteLine();
    }
}