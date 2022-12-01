using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace evaluareexpresiealgebricaminimalist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public char[] operatoriArray = { '+' , '-' , '*' , '/' , '=' ,' '};

        public bool isOperator(char v) {
           
            bool gasit = false;
           
            for (int i = 0; i < operatoriArray.Length && gasit == false; i++)
           {
               if (operatoriArray[i] == v) 
               {
                   gasit = true;
               }
           }

            return gasit;
        }
        public void resetall()
        {
            for (int i = listBox1.Items.Count; i >=0 ; i--)
            {
                try
                {
                    listBox1.Items.RemoveAt(i);
                }
                catch { }

            }
            for (int i = listBox1.Items.Count; i >= 0; i--)
            {
                try
                {
                    listBox2.Items.RemoveAt(i);
                }
                catch { }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           //reset listbox1 si 2
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            textBox1.Text += ' ';
            char vv;
            string xx;
            int cx, px;
            cx = 0;
            px = 0;
            double a;
            double b;

            for (int i = 0; i < textBox1.Text.Length ; i++)
            {
                px = cx;
                textBox1.Select(i, 1);
                vv = Convert.ToChar(textBox1.SelectedText);
                if (isOperator(vv) == true)
                {
                   
                    listBox1.Items.Add(vv);
                     cx = i++; 
                }
               
                    textBox1.Select(px, cx - px);
                    
                        xx = textBox1.SelectedText.Trim();
                    if (xx != "")
                    {
                        listBox2.Items.Add(xx);
                    }
                  
                Thread.Sleep(2);
            }
            a = Double.Parse(listBox2.Items[0].ToString());
            b = Double.Parse(listBox2.Items[2].ToString());

            if (listBox2.Items[1].ToString() == "+")
            {
                textBox1.Text += " = " + (a + b).ToString();
            }
            else if (listBox2.Items[1].ToString() == "-")
            {
                textBox1.Text += " = " + (a - b).ToString();
            }
            else if (listBox2.Items[1].ToString() == "/")
            {
                textBox1.Text += " = " + (a / b).ToString();
            }
            else if (listBox2.Items[1].ToString() == "*")
            {
                textBox1.Text += " = " + (a * b).ToString();
            }

           
        }
    }
}
