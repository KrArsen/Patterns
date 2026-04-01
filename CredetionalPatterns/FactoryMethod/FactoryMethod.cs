namespace CreationalPatterns.FactoryMethod
{
    abstract class Product
    {
        public abstract void Use();
    }

    class ConcreteProduct : Product
    {
        public override void Use()
        {
            Console.WriteLine("Factory Method працює");
        }
    }

    abstract class Creator
    {
        public abstract Product CreateProduct();
    }

    class ConcreteCreator : Creator
    {
        public override Product CreateProduct()
        {
            return new ConcreteProduct();
        }
    }
}