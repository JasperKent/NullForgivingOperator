namespace NullForgivingOperator.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Licence Licence { get; set; } = null!;
    }
}
