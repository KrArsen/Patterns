namespace StructuralPatterns.Bridge
{
    // Implementor
    public interface IImplementor
    {
        string OperationImp();
    }

    // ConcreteImplementorA
    public class ConcreteImplementorA : IImplementor
    {
        public string OperationImp()
        {
            return "ConcreteImplementorA Operation";
        }
    }

    // Abstraction
    public class Abstraction
    {
        protected IImplementor _implementor;

        public Abstraction(IImplementor implementor)
        {
            _implementor = implementor;
        }

        public virtual string Operation()
        {
            return "Abstraction: " + _implementor.OperationImp();
        }
    }

    public static class BridgeDemo
    {
        public static void Show()
        {
            Abstraction abstraction = new Abstraction(new ConcreteImplementorA());
            Console.WriteLine("    [Bridge] -> " + abstraction.Operation());
        }
    }
}
