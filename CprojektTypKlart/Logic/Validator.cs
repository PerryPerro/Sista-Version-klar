namespace Logic
{
    public class Validator
    {
        public class validera
        {
            public validera()
            {
            }
            public static bool emptyTextbox(string text)
            {
                if (string.IsNullOrEmpty(text) || text == "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
 
        }
    }
}
