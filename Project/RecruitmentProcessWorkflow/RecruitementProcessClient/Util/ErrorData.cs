namespace RecruitementProcessClient.Util
{
    public static class ErrorData
    {
        public static string GetError(string message = null, bool isSuccess = true)
        {
            string returnValue = string.Empty;

            if (!isSuccess)
            {
                returnValue = "Invalid request";
            }
            else if (message != null && message.Contains("501"))
            {
                returnValue = "Sequence no cannot be duplicated.";
            }
            else
            {
                returnValue = message;
            }

            return returnValue;
        }
    }
}