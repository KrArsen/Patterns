namespace CreationalPatterns.Builder
{
    class Builder
    {
        private string product = "";

        public void BuildPartA() => product += "PartA ";
        public void BuildPartB() => product += "PartB ";

        public string GetResult() => product;
    }
}