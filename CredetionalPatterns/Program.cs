using CreationalPatterns.Singleton;
using CreationalPatterns.FactoryMethod;
using CreationalPatterns.AbstractFactory;
using CreationalPatterns.Builder;
using CreationalPatterns.Prototype;
using CreationalPatterns.ObjectPool;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
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
    }
}