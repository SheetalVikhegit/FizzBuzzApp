using FizzBuzz.Interfaces;

namespace FizzBuzz
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly List<string> _divisionsPerformed;

        public FizzBuzzService()
        {
            _divisionsPerformed = new List<string>();
        }

        public string ProcessValue(int value)
        {
            if (value % 3 == 0 && value % 5 == 0)
            {
                _divisionsPerformed.Add($"Divided {value} by 3");
                _divisionsPerformed.Add($"Divided {value} by 5");
                return "FizzBuzz";
            }
            else if (value % 3 == 0)
            {
                _divisionsPerformed.Add($"Divided {value} by 3");
                return "Fizz";
            }
            else if (value % 5 == 0)
            {
                _divisionsPerformed.Add($"Divided {value} by 5");
                return "Buzz";
            }
            else
            {
                return "Invalid Item";
            }
        }

        public List<string> GetDivisionsPerformed()
        {
            return _divisionsPerformed;
        }
    }


}
