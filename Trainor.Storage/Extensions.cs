namespace Trainor.Storage;

public static class Extensions
{
    public static string ToFilterQueryString(this string[] input)
    {
        string output = "";
        if (input.Length > 1)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != "")
                {
                    output +=  input[i];
                    if (i != input.Length - 1)
                    {
                        output += "&";
                    }
                }
            } 
        }
        else
        {
            output = "&" + input[0];
        }
        return output;
    }
    
    public static string ToKeywordQueryString(this string input)
    {
        if (!input.Contains(' '))
        {
            return input;
        }
        string[] delimiterArray = input.Split(" ");
        string output = "";
        for (int i = 0; i < delimiterArray.Length; i++)
        {
            if (delimiterArray[i] != "")
            {
                output +=  delimiterArray[i];
                if (i != delimiterArray.Length - 1)
                {
                    output += "_";
                }
            }
        }
        return output;
    }
}