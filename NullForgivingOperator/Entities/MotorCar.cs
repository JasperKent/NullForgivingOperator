namespace NullForgivingOperator.Entities
{
    public class MotorCar
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public Person? Driver { get; set; }
        public Engine Engine { get; set; } = null!;
    }
}
