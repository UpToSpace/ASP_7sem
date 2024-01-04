using System;
using System.Windows.Forms;
using WinFormApp.ServiceReference1;

namespace WinFormApp
{
    public partial class Form1 : Form
    {
        private readonly SimplexSoapClient _client;
        
        public Form1()
        {
            _client = new SimplexSoapClient();
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var res = _client.Sum(
                new A { s = S1.Text, k = Convert.ToInt32(K1.Text), f = float.Parse(F1.Text) }, 
                new A { s = S2.Text, k = Convert.ToInt32(K2.Text), f = float.Parse(F2.Text) }
            );

            S3.Text = res.s;
            K3.Text = res.k.ToString();
            F3.Text = res.f.ToString();
        }
    }
}
