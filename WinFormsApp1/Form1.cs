using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public bool stop = false;
        public SimprMessaging si;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            si = new SimprMessaging(Program.mainForm);
        }

        public void SetMessage(string m)
        {
            simprLabelCond.Text = m;
        }
        
        public void AddLineToLogs(string m)
        {
            textBox1.Text += m + Environment.NewLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stop = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}