namespace Auth_Service.Models
{
    public static class FakeUsers
    {
        public static List<User> Users = new()
        {
            new User{Email= "apple@shop.com", Password = "apple123", role="Apple"},

            new User{Email= "elsha3er@shop.com", Password = "elsha3er456", role="Elsha3er"}
        };
    }
}
