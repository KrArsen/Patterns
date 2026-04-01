namespace CreationalPatterns.AbstractFactory
{
    interface IButton
    {
        void Paint();
    }

    class WindowsButton : IButton
    {
        public void Paint() => Console.WriteLine("Windows Button");
    }

    class MacButton : IButton
    {
        public void Paint() => Console.WriteLine("Mac Button");
    }

    interface IFactory
    {
        IButton CreateButton();
    }

    class WindowsFactory : IFactory
    {
        public IButton CreateButton() => new WindowsButton();
    }
}