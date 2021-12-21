namespace Trainor.Storage;

public static class Extensions
{
    public static string ToFilterQueryString(this string[] input)
    {
        string output = "";
        if (input.Length > 0)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != "")
                {
                    output += "subjects=" + input[i];
                    if (i != input.Length - 1)
                    {
                        output += "&";
                    }
                }
            } 
        }
        return output;
    }
}