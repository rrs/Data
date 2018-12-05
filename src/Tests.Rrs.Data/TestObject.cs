namespace Tests.Rrs.Data
{
    class TestObject
    {
        public int Id { get; }
        public string Name { get; }

        public TestObject(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
