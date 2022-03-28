using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace T_I_lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string alph = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя _-,.!?:;";
        string text = "";
        string result = "";
        int key = 1;
        public static string Encryption_Cesar(string text, int key)
        {
            var res = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alph.Length; j++)
                    if (text[i] == alph[j])
                    {
                        res.Append(alph[(j + key) % alph.Length]);
                    }
            }
            return res.ToString();
        }
        public string Encrypt_Scytales(string text, int d)
        {
            var k = text.Length % d;
            if (k > 0)
            {
                text += new string(' ', d - k);
            }

            var column = text.Length / d;
            var result = "";

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    result += text[i + column * j].ToString();
                }
            }

            return result;
        }
        public string Decrypt_Scytales(string text, int d)
        {
            var column = text.Length / d;
            var result = new char[text.Length];
            int index = 0;
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    result[i + column * j] = text[index];
                    index++;
                }
            }

            return string.Join("", result);
        }
        public static string Decryption_Cesar(string crypt, int key)
        {
            var res = new StringBuilder();
            for (int i = 0; i < crypt.Length; i++)
            {
                for (int j = 0; j < alph.Length; j++)
                    if (crypt[i] == alph[j])
                    {
                        res.Append(alph[(j - key + alph.Length) % alph.Length]);
                    }
            }
            return res.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            key = int.Parse(textBox1.Text);
            text = richTextBox1.Text;
            result = Decryption_Cesar(text, key);
            richTextBox2.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            key = int.Parse(textBox1.Text);
            text = richTextBox1.Text;
            result = Encryption_Cesar(text, key);
            richTextBox2.Text = result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            key = int.Parse(textBox2.Text);
            text = richTextBox4.Text;
            result = Encrypt_Scytales(text, key);
            richTextBox3.Text = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            key = int.Parse(textBox2.Text);
            text = richTextBox4.Text;
            result = Decrypt_Scytales(text, key);
            richTextBox3.Text = result;
        }


        private void button7_Click(object sender, EventArgs e)
        {
            Random rand1 = new Random();
            tb_a.Text = (rand1.Next() % (100 - 1) + 1).ToString();
            tb_A1.Text = step_mod(int.Parse(tb_g.Text), int.Parse(tb_a.Text), int.Parse(tb_p.Text)).ToString();
            //tb_A1.Text = (Math.Pow(int.Parse(tb_g.Text), int.Parse(tb_a.Text)) % int.Parse(tb_p.Text)).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tb_K.Text = step_mod(int.Parse(tb_B.Text), int.Parse(tb_a.Text), int.Parse(tb_p.Text)).ToString();
            //tb_K.Text = (Math.Pow(int.Parse(tb_B.Text), int.Parse(tb_a.Text)) % int.Parse(tb_p.Text)).ToString();
        }

        public static int step_mod(int input, int exponent, int modul)
        {
            int d = 1, t = input;
            string bin = Convert.ToString(exponent, 2);
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                if (bin[i] == '1')
                {
                    d = d * t % modul;
                }
                t = t * t % modul;
            }
            return d;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Random rand1 = new Random();
            tb_p.Text = (rand1.Next() % (1000 - 100) + 100).ToString();
            tb_g.Text = (rand1.Next() % (9 - 1) + 1).ToString();
        }

        public static string rand_prost_ch()
        {
            Random rand1 = new Random();
            string randS = (rand1.Next() % (9 - 1) + 1).ToString();
            return randS;
        }
    }
}
