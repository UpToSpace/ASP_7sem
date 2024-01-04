using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace PWS_7_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var req = (HttpWebRequest)WebRequest.Create(@"http://localhost:40124/PWS_7/Feed1/students/" + textBox1.Text + "/notes/atom?format=rss");
            var res = (HttpWebResponse)req.GetResponse();
            var content = new StreamReader(res.GetResponseStream()).ReadToEnd();
            richTextBox1.Text = content;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var req = (HttpWebRequest)WebRequest.Create(@"http://localhost:40124/PWS_7/Feed1/students/" + textBox1.Text + "/notes/json?format=atom");
            var res = (HttpWebResponse)req.GetResponse();
            var content = new StreamReader(res.GetResponseStream()).ReadToEnd();
            richTextBox1.Text = content;
        }
    }
}
