
namespace API_Test_UserChangePass.Models
{
    public static class HashPasswordBCrypt
    {

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

    }
}
 //////////// < PackageReference Include = "BCrypt.Net-Next" Version = "4.0.3" />


////استفاده
//string plainPassword = "YourPassword123";
//string hashedPassword = HashPasswordBCrypt.HashPassword(plainPassword);

//// ذخیره hashedPassword در دیتابیس
//Console.WriteLine("Hashed Password: " + hashedPassword);