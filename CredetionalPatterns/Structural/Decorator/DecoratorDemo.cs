namespace StructuralPatterns.Decorator
{
    public abstract class Component
    {
        public abstract string Operation();
    }

    public class ConcreteComponent : Component
    {
        public override string Operation() => "ConcreteComponent";
    }

    public abstract class Decorator : Component
    {
        protected Component _component;
        public Decorator(Component component) { _component = component; }
        public override string Operation()
        {
            return _component != null ? _component.Operation() : string.Empty;
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component component) : base(component) { }
        public override string Operation() => $"ConcreteDecoratorA({base.Operation()})";
    }

    public static class DecoratorDemo
    {
        public static void Show()
        {
            var component = new ConcreteComponent();
            var decorator1 = new ConcreteDecoratorA(component);
            Console.WriteLine("    [Decorator] -> " + decorator1.Operation());
        }
    }
}
