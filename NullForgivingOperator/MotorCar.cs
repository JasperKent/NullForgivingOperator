using System.Diagnostics.CodeAnalysis;

namespace NullableReferences
{
    public class MotorCar
    {
        private Person? _driver;
        private Engine _engine;

        public MotorCar(Person? driver, Engine engine)
        {
            _driver = driver;
            _engine = engine;
        }

        public override string ToString()
        {
            if (IsValid(_driver))
                return $"{_driver.Name} drives a {_engine.Capacity}cc car.";
            else
                return "No driver";
        }

        private static bool IsValid ([NotNullWhen(true)] Person? driver)
        {
            return driver != null && driver.Name != "";
        }
    }
}
