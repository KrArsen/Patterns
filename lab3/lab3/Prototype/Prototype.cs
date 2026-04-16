namespace CreationalPatterns.Prototype
{
    class Prototype
    {
        public int Value;

        public Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
}