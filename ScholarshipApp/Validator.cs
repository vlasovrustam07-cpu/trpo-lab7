namespace ScholarshipApp
{
    public class Validator
    {
        public static bool check(string x)
        {
            if (string.IsNullOrWhiteSpace(x)) return false;
            foreach (char ch in x)
                if (char.IsDigit(ch)) return false;
            return true;
        }
    }
}
