namespace WebApp.Utils
{
    public static class ParsingTools
    {
        public static string ToHMTimestamp(int input)
        {
            if (input % 100 != 0)
            {
                input -= 20;
            }

            string inputAsString = input.ToString();

            return inputAsString.Insert(inputAsString.Length - 2, ":");
        }
    }
}
