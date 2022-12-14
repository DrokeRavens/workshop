namespace Users.Core.Extensions;

public static class StringExtensions
{
    public static string Hash(this string toHash)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(toHash);
        
        using (var hash = System.Security.Cryptography.SHA512.Create())
        {
            var hashedInputBytes = hash.ComputeHash(bytes);

            var hashedInputStringBuilder = new System.Text.StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}