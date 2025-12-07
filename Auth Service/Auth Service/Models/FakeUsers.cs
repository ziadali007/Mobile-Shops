namespace Auth_Service.Models
{
    public static class FakeUsers
    {
        public static List<User> Users = new()
        {
            new User{Email= "//Put Your Account Email", Password = "Put Your Account Password", role="The Keyword That Will Route To Service"},

            new User{Email= "//Put Your Account Email", Password = "Put Your Account Password", role="The Keyword That Will Route To Service"}
        };
    }
}
