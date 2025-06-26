while (true)
{
    PasswordValidator.ValidatePassword(GetUserPassword());
}

static string GetUserPassword()
{
    Console.Write("Enter a password: ");
    string password = Console.ReadLine();
    return password;
}

public class PasswordValidator
{
    public static void ValidatePassword(string password)
    {
        bool isValid = true;
        bool hasSymbol = false;
        bool hasNumber = false;
        bool hasUpper = false;

        if (password.Length < 6 || password.Length > 13) isValid = false;

        foreach (char letter in password)
        {
            if (letter == 'T' || letter == '&') isValid = false;
            if (char.IsUpper(letter)) hasUpper = true;
            if (char.IsNumber(letter)) hasNumber = true;
            if (char.IsSymbol(letter)) hasSymbol = true;
        }

        if (isValid) Console.WriteLine("Password accepted.");
        else Console.WriteLine("Password invalid. Password must satisfy password complexity requirements. Thanks, Ingelmar.");
        Console.WriteLine();
    }
}