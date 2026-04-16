namespace StructuralPatterns.Facade
{
    public class Subsystem1
    {
        public string Operation1() => "Subsystem1: Ready!\n";
    }

    public class Subsystem2
    {
        public string OperationZ() => "Subsystem2: Get ready!\n";
    }

    public class Facade
    {
        protected Subsystem1 _subsystem1;
        protected Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            _subsystem1 = subsystem1;
            _subsystem2 = subsystem2;
        }

        public string Operation()
        {
            string result = "Facade initializes subsystems:\n";
            result += "        " + _subsystem1.Operation1();
            result += "        " + _subsystem2.OperationZ();
            return result;
        }
    }

    public static class FacadeDemo
    {
        public static void Show()
        {
            Facade facade = new Facade(new Subsystem1(), new Subsystem2());
            Console.WriteLine("    [Facade] -> " + facade.Operation().TrimEnd('\n'));
        }
    }
}
