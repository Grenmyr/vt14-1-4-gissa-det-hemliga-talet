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
                var guess = TextBox.Text;             
                switch (SecretNumber.Outcome)
                {
                    case Outcome.Indefinite:
                        break;
                    case Outcome.Low:
                        Guesses.Text = "För lågt";
                        break;
                    case Outcome.High:
                        Guesses.Text = "För högt";
                        break;
                    case Outcome.Correct:
                        Guesses.Text = "Du gissade rätt!";
                        break;
                    case Outcome.NoMoreGuesses:
                        Guesses.Text = "Du har sluit på gissningar";
                        break;
                    case Outcome.PreviousGuess:
                        Guesses.Text = "Du har redan gissat " + guess;
                        break;
                    default:
                        break;
                }
                
            }
            

        }
    }
}