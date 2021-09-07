using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customer_tracking_app
{
    public partial class Animation : Form
    {
        public Animation()
        {
            InitializeComponent();
        }
        Timer t = new Timer();
        private void Animation_Load(object sender, EventArgs e)
        {

            t.Interval = 2000;
            t.Tick += new EventHandler(onTimerTicked);
            t.Start();
        }
        public void onTimerTicked(object sender, EventArgs e)
        {
            t.Stop();
            Animation kapat = new Animation();
            kapat.Close();
            Login frm1 = new Login();
            frm1.Show();
            this.Hide();

        }

       
    }
}
