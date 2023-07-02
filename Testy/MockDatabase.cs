using disability_map.Models;

namespace Testy
{
    public class MockDatabase
    {
        public static List<User> GetFakeUsers()
        {
            return new List<User>()
            {
                new User
                {
                    Id = 1,
                    Login = "TestUser",
                    Email = "TestUser@gmail.com",
                    PasswordHash = new byte[0],
                    PasswordSalt = new byte[0]
                },
                new User
                {
                    Id = 2,
                    Login = "TestUser2",
                    Email = "TestUser2@gmail.com",
                    PasswordHash = new byte[0],
                    PasswordSalt = new byte[0]
                }
            };
        }
    }
}
