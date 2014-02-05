using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gissa_det_hemliga_talet.Model;

namespace Gissa_det_hemliga_talet
{
    public partial class _default : System.Web.UI.Page
    {

        public SecretNumber SecretNumber
        {
            get
            {
                return Session["secretNumber"] as SecretNumber;
            }
            set
            {
                Session["secretNumber"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox.Focus();     
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
           
            if (IsValid)
            {
                if (SecretNumber == null)
                {
                    SecretNumber = new SecretNumber();
                }
                var guess = int.Parse(TextBox.Text);
                switch (SecretNumber.MakeGuess(guess))
                {
                    case Outcome.Indefinite:
                        break;
                    case Outcome.Low:
                        Guess.Text = "För lågt!";
                        break;
                    case Outcome.High:
                        Guess.Text = "För högt!";
                        break;
                    case Outcome.Correct:
                        Guess.Text = String.Format("Du gissade rätt! Det tog {0} försök.", SecretNumber.Count);
                        SubmitPanel.Enabled = false;
                        ResetButton.Visible = true;
                        break;
                    case Outcome.NoMoreGuesses:
                        Guess.Text = String.Format("Du har sluit på gissningar. Det hemliga talet var {0}", SecretNumber.Number);
                        SubmitPanel.Enabled = false;
                        ResetButton.Visible = true;
                        break;
                    case Outcome.PreviousGuess:
                        Guess.Text = String.Format("Du har redan gissat {0}.", guess);
                        break;
                    default:
                        break;
                }
                PreviousGuesses.Text = String.Join(" ", SecretNumber.PreviousGuesses);                
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        { 
            SecretNumber.Initialize();
        }
    }
}