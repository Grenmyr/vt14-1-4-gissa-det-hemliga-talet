using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gissa_det_hemliga_talet
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox.Focus();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
           
            if (IsValid)
            {

            }
            else {
                
            }

        }
    }
}