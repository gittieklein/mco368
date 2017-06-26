using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Eligibility
    {
        private int age;
        private int yearsInUS;
        private bool naturalBornCitizen;
        private int priorTerms;
        private bool rebelled;

        public Eligibility(int age, int yearsInUS, bool naturalBornCitizen, int priorTerms, bool rebelled)
        {
            this.age = age;
            this.yearsInUS = yearsInUS;
            this.naturalBornCitizen = naturalBornCitizen;
            this.priorTerms = priorTerms;
            this.rebelled = rebelled;
        }
        public bool EligiblePrez()
        {
            if (age >= 35 && yearsInUS >= 14 && naturalBornCitizen && priorTerms <= 1 && !rebelled)
            {
                return true;
            }
            return false;
        }
    }
}
