namespace StructuralPatterns.Adapter
{
    // Target
    public interface ITarget
    {
        string GetRequest();
    }

    // Adaptee
    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request";
        }
    }

    // Adapter
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{_adaptee.GetSpecificRequest()}'";
        }
    }

    public static class AdapterDemo
    {
        public static void Show()
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);
            Console.WriteLine("    [Adapter] -> " + target.GetRequest());
        }
    }
}
