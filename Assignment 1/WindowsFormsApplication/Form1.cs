using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Classes;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void determineEligibilityButton_Click_1(object sender, EventArgs e)
        {
            int age;
            bool testAge = int.TryParse(ageTextBox.Text, out age);
            if(!testAge)
            {
                validLabel.Text = "Plese enter a valid age";
                eligibleLabel.Text = " ";
            }

            int years;
            bool testYears = int.TryParse(yearsInUSTextBox.Text, out years);
            if (!testYears)
            {
                validLabel.Text = "Plese enter a valid number of years";
                eligibleLabel.Text = " ";
            }

            int priorTerms;
            bool testTerms = int.TryParse(priorTermsTextBox.Text, out priorTerms);
            if (!testTerms)
            {
                validLabel.Text = "Plese enter a valid number of terms";
                eligibleLabel.Text = " ";
            }

            bool citizen = false;
            if (citizenCheckBox.Checked)
            {
                citizen = true;
            }

            bool rebelled = false;
            if (rebelledUSCheckBox.Checked)
            {
                rebelled = true;
            }

            if (testTerms && testYears && testAge)
            {
                Eligibility eligiblePrez = new Eligibility(age, years, citizen, priorTerms, rebelled);
                bool couldRun = eligiblePrez.EligiblePrez();

                if (couldRun)
                {
                    eligibleLabel.Text = "You are eligible to run for President of the US!";
                    validLabel.Text = " ";
                }
                else
                {
                    eligibleLabel.Text = "You are not eligible to run for President of the US!";
                    validLabel.Text = " ";
                }
            }
        }
    }
}
