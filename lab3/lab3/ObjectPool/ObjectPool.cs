namespace CreationalPatterns.ObjectPool
{
    class ObjectPool
    {
        private List<string> pool = new List<string>();

        public string GetObject()
        {
            if (pool.Count > 0)
            {
                var obj = pool[0];
                pool.RemoveAt(0);
                return obj;
            }
            return "Новий об'єкт";
        }

        public void ReturnObject(string obj)
        {
            pool.Add(obj);
        }
    }
}