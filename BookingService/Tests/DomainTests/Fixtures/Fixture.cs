using Bogus;
using Bogus.DataSets;

namespace HotelBookingTest.Fixtures
{
    internal class Fixture
    {
        public static long GetId()
        {
            return new Randomizer().Long(2, 1000);
        }

        public static int GetNumber(int min = 1, int max = 999)
        {
            return new Randomizer().Int(min, max);
        }

        public static double GetPrice(double min = 1, double max = 999)
        {
            return new Randomizer().Double(min, max);
        }

        public static string GetString(int size = 10)
        {
            return new Randomizer().String(size);
        }

        public static string GetName()
        {
            return new Name().FirstName();
        }

        public static string GetEmail()
        {
            return new Internet().Email();
        }

        public static string GetPassword()
        {
            return new Internet().Password();
        }

        public static string GetCpf()
        {
            return new Randomizer().Long(10000000000, 99999999999).ToString("###.###.###-##");
        }
    }
}
