using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var calc = new localhost.WebService1();
            var result = calc.Add(1, 2);
            Label1.Text = result.ToString();
        }
    }
}