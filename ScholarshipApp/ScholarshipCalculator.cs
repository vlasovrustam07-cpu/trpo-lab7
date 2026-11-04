namespace ScholarshipApp
{
    public class ScholarshipCalculator
    {
        public int calc(double a)
        {
            if (a >= 4.5) return 3000;
            else return 0;
        }



        public int total(List<Student> l)
        {
            int r = 0;
            for (int i = 0; i < l.Count; i++)
                r = r + l[i].st;
            return r;
        }
    }
}
