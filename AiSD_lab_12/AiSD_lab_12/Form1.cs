using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiSD_lab_12
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CircularBuffer buffer = new CircularBuffer();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = (Math.Pow(int.Parse(textBox1.Text), 2)).ToString();
                //buffer.addBuffer(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Неверное значение");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = (Math.Sqrt(int.Parse(textBox1.Text))).ToString();
                //buffer.addBuffer(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Неверное значение");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = buffer.procrutkaZnacheniy();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buffer.GetTMessageBoxString();
        }

        

        private void textBox1_Leave(object sender, EventArgs e)
        {
            buffer.addBuffer(textBox1.Text);
        }
    }
    public class CircularBuffer
    {
        string[] arrBuffer; //Сам буфер
        int curIndex; // Текущий индекс
        int sizeBuffer; // Размер буфера
        int k; // для прокрутки

        public CircularBuffer()
        {
            sizeBuffer = 4;
            arrBuffer = new string[sizeBuffer];
            curIndex = 0;
        }
        public void addBuffer(string addElement)
        {
            arrBuffer[curIndex] = addElement;
            curIndex++;
            if (curIndex == sizeBuffer) curIndex = 0;
            k = 0;
        }
        public string procrutkaZnacheniy()
        {
            int prom = curIndex;
            if (prom == 0) prom = sizeBuffer - 1;
            if(k == prom && prom != 0) return arrBuffer[prom + 1];
           
            k++;
            if (((prom - (k - 1))) >= 0) return arrBuffer[((prom - (k - 1)))];
            //else return arrBuffer[sizeBuffer - curIndex - k - 1];
            return arrBuffer[((sizeBuffer + prom - k - 1) % sizeBuffer)];
        }

        public void GetTMessageBoxString()
        {
            MessageBox.Show(string.Join("\n", arrBuffer));
        }
    }
}
//0 1 2 3 
