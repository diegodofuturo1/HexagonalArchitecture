using Bogus;
using Bogus.DataSets;

namespace HotelBookingTest.Fixtures
{
    internal class Fixture
    {
        public static long GetId()
        {
            return new Randomizer().Long(1, 1000);
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
