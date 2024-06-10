using System;
using System.Text;

class PasswordGenerator
{
    static void Main()
    {
        Console.WriteLine("Password Generator");

        Console.Write("Enter the desired length of the password: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Include uppercase letters? (y/n): ");
        bool includeUppercase = Console.ReadLine().ToLower() == "y";

        Console.Write("Include lowercase letters? (y/n): ");
        bool includeLowercase = Console.ReadLine().ToLower() == "y";

        Console.Write("Include digits? (y/n): ");
        bool includeDigits = Console.ReadLine().ToLower() == "y";

        Console.Write("Include special characters? (y/n): ");
        bool includeSpecial = Console.ReadLine().ToLower() == "y";

        string password = GeneratePassword(length, includeUppercase, includeLowercase, includeDigits, includeSpecial);
        Console.WriteLine("Generated Password: " + password);
    }

    static string GeneratePassword(int length, bool includeUppercase, bool includeLowercase, bool includeDigits, bool includeSpecial)
    {
        const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowercase = "abcdefghijklmnopqrstuvwxyz";
        const string digits = "0123456789";
        const string special = "!@#$%^&*()-_=+<>?";

        StringBuilder characterSet = new StringBuilder();

        if (includeUppercase)
            characterSet.Append(uppercase);
        if (includeLowercase)
            characterSet.Append(lowercase);
        if (includeDigits)
            characterSet.Append(digits);
        if (includeSpecial)
            characterSet.Append(special);

        if (characterSet.Length == 0)
            throw new ArgumentException("At least one character set must be selected.");

        Random random = new Random();
        StringBuilder password = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(characterSet.Length);
            password.Append(characterSet[index]);
        }

        return password.ToString();
    }
}
