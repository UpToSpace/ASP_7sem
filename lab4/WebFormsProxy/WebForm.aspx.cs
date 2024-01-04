using System;
using System.Web.UI;

namespace WebFormsProxy
{
    public partial class _WebForm : Page
    {
        private Simplex proxyClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            proxyClient = new Simplex();
        }

        protected void sum_Click(object sender, EventArgs e)
        {
            int val1, val2;
            if (int.TryParse(x.Text.ToString(), out val1) && 
                int.TryParse(y.Text.ToString(), out val2))
            {
                result.Text = proxyClient.Add(val1, val2).ToString();
            }
            else
            {
                result.Text = "Error!";
            }
        }
    }
}