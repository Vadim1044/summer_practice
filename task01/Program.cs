using System;
namespace task01;

public static class StringExtensions
{
    public static bool IsPalindrome(this string str)
    {
        if (str == "" || str == null)
        {
            return false;
        }
        string temp = string.Concat(str.ToLower().Where(c => !char.IsWhiteSpace(c) && !char.IsPunctuation(c)));
        Console.WriteLine(temp);

        for (int i = 0; i < temp.Length; i++)
            if (temp[i] != temp[temp.Length - i - 1]) return false;
        return true;
    }
}
