using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRA_RIMS
{
    public partial  class Keyboard : Form
    {
        Label TB;
        Button bt;
        Label LB;
        public Keyboard(Label tb, Label LbPayable,Button BT)
        {
            InitializeComponent();
            bt = BT;
               LBP.Text = tb.Text;
            this.LB = LbPayable;
           
        }

        public Keyboard()
        {
         
            InitializeComponent();

       
        }

      
      
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, (sender as Button).Text);
            textBox1.Focus();
            {
                textBox1.SelectionStart = textBox1.Text.Length ; 
            }
            textBox1.SelectionLength = 0;
            SendKeys.Send("{A}");
            SendKeys.Send("{BACKSPACE}");
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                LB.Text = textBox1.Text;
               

                SendKeys.Send("{ENTER}");
                this.Close();
                bt.PerformClick();
            }
            catch
            {

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                textBox1.SelectionStart = textBox1.Text.Length ; 
            
            textBox1.SelectionLength = 0;
            textBox1.SelectionLength = 0;
            textBox1.Focus();
           
            }
            catch {textBox1.SelectionStart = textBox1.Text.Length ; 
            textBox1.SelectionLength = 0;
            textBox1.Focus();
      
            }
            SendKeys.Send("{A}");
            SendKeys.Send("{BACKSPACE}");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
       

        }

        private void Keyboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape )
            
            {
                TB.Text = textBox1.Text;
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                Print.PerformClick();
            }
        }
        
    }
}
