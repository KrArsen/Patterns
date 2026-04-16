namespace StructuralPatterns.Proxy
{
    public interface ISubject
    {
        string Request();
    }

    public class RealSubject : ISubject
    {
        public string Request() => "RealSubject: Handling Request.";
    }

    public class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            _realSubject = realSubject;
        }

        public string Request()
        {
            if (CheckAccess())
            {
                return "Proxy: " + _realSubject.Request();
            }
            return "Proxy: Access Denied.";
        }

        public bool CheckAccess()
        {
            // Some real checks should go here.
            return true;
        }
    }

    public static class ProxyDemo
    {
        public static void Show()
        {
            RealSubject realSubject = new RealSubject();
            Proxy proxy = new Proxy(realSubject);
            Console.WriteLine("    [Proxy] -> " + proxy.Request());
        }
    }
}
