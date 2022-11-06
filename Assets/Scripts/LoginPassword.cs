/// <summary>
/// Static class to hold the login password.
/// </summary>
public static class LoginPassword
{
    public static string LoginScreenPassword = "B6m3";

    public static bool IsPasswordCorrect(string password)
    {
        return password == LoginScreenPassword;
    }
}
