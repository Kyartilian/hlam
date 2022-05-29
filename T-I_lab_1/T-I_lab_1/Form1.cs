using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;


namespace T_I_lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //static string alph = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя _-~,.!?:;<>|'/0123456789AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
        static string alph = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
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
                    d = (d * t) % modul;
                }
                t = (t * t) % modul;
            }
            return d;
        }
        /*public static int step_mod_2(int input, int exponent, int modul)
        {
            int y = 1, s = input;
            string bin = Convert.ToString(exponent, 2);
            for (int i = 0; i < bin.Length ; i++)
            {
                s = s * s % modul;
                if (bin[i] == '1')
                {
                    y = y * t % modul;
                }
                
            }
            return y;
        }*/

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

        char[,] alfrus_Pol = {
                            {'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё'},
                            {'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М'},
                            {'Н', 'О', 'П', 'Р', 'С', 'Т', 'У'},
                            {'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ'},
                            {'Ы', 'Ь', 'Э', 'Ю', 'Я', '0', '1'},
                            {'2','3', '4', '5', '6', '7', '8'},
                            {'9', ' ', ',', '.', '!', '?', ';'} //7 x 7
                         };
        private string Polibiy(string text, bool index = true) //true = зашифровать, false = дешифровать
        {
            var result = new StringBuilder();
            //var ch = new char[0];
            //var ish_soo_mass = new char[7, 7]; //исходноое собщение преобразуем в массив char

            /*for (int i = 0; i < Math.Sqrt(ish_soo_mass.Length) ;  i ++)
            {
                for (int j = 0; j < Math.Sqrt(ish_soo_mass.Length); j++)
                {
                    ish_soo_mass[i,j] = text[i+j];
                }
            }*/
            bool br = false;
            if (index)
            {
                for (int i = 0; i < text.Length; i++)
                {

                    for (int j = 0; j < Math.Sqrt(alfrus_Pol.Length); j++)
                    {
                        for (int k = 0; k < Math.Sqrt(alfrus_Pol.Length); k++)
                        {
                            if (text[i] == alfrus_Pol[j, k])
                            {
                                if (j == 6)
                                {
                                    j = -1;
                                }
                                if (k == 6)
                                {
                                    k = -1;
                                }
                                result.Append(alfrus_Pol[j + 1, k + 1]);
                                //ch.Append(alfrus_Pol[j + 1, k + 1]);
                                br = true;
                                break;
                            }
                        }
                        if (br)
                        {
                            br = false;
                            break;
                        }
                    }

                }
            }
            else
            {
                for (int i = 0; i < text.Length; i++)
                {

                    for (int j = 0; j < Math.Sqrt(alfrus_Pol.Length); j++)
                    {
                        for (int k = 0; k < Math.Sqrt(alfrus_Pol.Length); k++)
                        {
                            if (text[i] == alfrus_Pol[j, k])
                            {
                                if (j == 0)
                                {
                                    j = 7;
                                }
                                if (k == 0)
                                {
                                    k = 7;
                                }
                                result.Append(alfrus_Pol[j - 1, k - 1]);
                                br = true;
                                break;
                            }
                        }
                        if (br)
                        {
                            br = false;
                            break;
                        }
                    }
                }
            }
            return result.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string res;
            res = Polibiy(richTextBox6.Text, true);
            richTextBox5.Text = res;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string res;
            res = Polibiy(richTextBox6.Text, false);
            richTextBox5.Text = res;
        }

        static int p_RSA = 11;
        static int q_RSA = 13;
        static int n_RSA = p_RSA * q_RSA;
        static int fun_E_RSA = (p_RSA - 1) * (q_RSA - 1);
        static int d_RSA = Calculate_d(fun_E_RSA);
        static int e_RSA = Calculate_e(d_RSA, fun_E_RSA);
        private void button14_Click(object sender, EventArgs e)
        {
            textBox3.Text = p_RSA.ToString();
            textBox4.Text = q_RSA.ToString();
            textBox7.Text = fun_E_RSA.ToString();
            textBox8.Text = d_RSA.ToString();
        }
        private List<int> RSA_Encod(List<int> ish_soo_int_arr, bool index = true)
        {
            var result_rsa = new List<int>();


            if (index)
            {
                for (int i = 0; i < ish_soo_int_arr.Count; i++)
                {
                    //int prom = (Math.Pow(ish_soo_int_arr[i], 1)).conv;
                    //int prom = int.Parse((double.Parse(Math.Pow(double.Parse(ish_soo_int_arr[i].ToString()),double.Parse(fun_E.ToString())).ToString())%n).ToString());
                    int prom = step_mod(ish_soo_int_arr[i], e_RSA, n_RSA);
                    //long prom = Convert.ToInt32(Math.Pow(ish_soo_int_arr[i], e) % n);
                    //int prom = 0;
                    result_rsa.Add(Convert.ToInt32(prom));
                }
            }
            else
            {
                for (int i = 0; i < ish_soo_int_arr.Count; i++)
                {
                    //int prom = (Math.Pow(ish_soo_int_arr[i], 1)).conv;
                    //int prom = int.Parse((double.Parse(Math.Pow(double.Parse(ish_soo_int_arr[i].ToString()),double.Parse(fun_E.ToString())).ToString())%n).ToString());
                    int prom = step_mod(ish_soo_int_arr[i], d_RSA, n_RSA);
                    //int prom = Convert.ToInt32(Math.Pow(ish_soo_int_arr[i], d) % n);
                    //int prom_2 = Convert.ToInt32(prom);
                    result_rsa.Add(prom);
                }
            }
            return result_rsa;
        }
        private static int Calculate_e(int d, int fun_E)
        {
            int e = 10;

            while (true)
            {
                if ((e * d) % fun_E == 1)
                    break;
                else
                    e++;
            }

            return e;
        }
        private static int Calculate_d(int fun_E)
        {
            int d = fun_E - 1;

            for (int i = 2; i <= fun_E; i++)
                if ((fun_E % i == 0) && (d % i == 0)) //если имеют общие делители
                {
                    d--;
                    i = 1;
                }

            return d;
        }
        private List<int> preobr_string_in_int(string ish_soo_string)
        {
            var res = new List<int>();
            //var res_1 = 
            for (int i = 0; i < ish_soo_string.Length; i++)
            {
                for (int j = 0; j < alph.Length; j++)
                {
                    if (ish_soo_string[i] == alph[j])
                    {
                        res.Add(j);
                        break;
                    }
                }
            }
            return res;
        }
        private string preobr_int_in_string(List<int> ish_soo_int)
        {
            var res = new StringBuilder();
            for (int i = 0; i < ish_soo_int.Count; i++)
            {
                for (int j = 0; j < alph.Length; j++)
                {
                    if ((ish_soo_int[i] % alph.Length) == j)
                    {
                        j = j;
                        res.Append(alph[j]);
                        j = 0;
                        break;
                    }
                }
            }
            return res.ToString();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string prom = preobr_int_in_string(RSA_Encod(preobr_string_in_int(richTextBox7.Text)));
            richTextBox8.Text = prom;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string prom = preobr_int_in_string(RSA_Encod(preobr_string_in_int(richTextBox7.Text), false));
            richTextBox8.Text = prom;
        }


        //static int p = 65537;
        static int p = 347;
        static Random rnd = new Random();
        //int g = (rnd.Next() % ((p - 1) - 1) + 1);
        int g = 52;
        //int Cd = (rnd.Next() % ((p - 1) - 100) + 100);
        int Cd = 218;
        int k = (rnd.Next() % ((p - 1) - 1) + 1);



        private int encryptEl_G_r()
        {
            //int k = (rnd.Next() % ((p - 1) - 1) + 1);
            int r = step_mod(g, k, p);
            return r;
        }

        private int encryptEl_G_e(int m = 20)
        {
            //int k = (rnd.Next() % ((p - 1) - 1) + 1);
            int dd = step_mod(g, Cd, p);
            int e = (step_mod(dd, k, p) * m) % p;
/*            int e = (step_mod(dd, k, p) * m);*/
            return e;
        }

        private int decryptEl_G(int r, int e)
        {
            int result = (step_mod(r, p - 1 - Cd, p) * e) % p;
            //int result = (step_mod(r, p - 1 - Cd, p) * e);
            return result;
        }

        private void button16_Click(object sender, EventArgs e) //Зашифровать
        {
            int m;
            try
            {
                m = int.Parse(textBox13.Text);
            }
            catch
            {
                m =  20;
            }
            int r = encryptEl_G_r();
            int e_0 = encryptEl_G_e(m);
            textBox5.Text = e_0.ToString();
            textBox9.Text = r.ToString();
        }

        private void button15_Click(object sender, EventArgs e) //Дешифровать
        {
            textBox13.Text = decryptEl_G(int.Parse(textBox9.Text), int.Parse(textBox5.Text)).ToString();
        }

        

        private void button18_Click(object sender, EventArgs e) //Шамир
        {
            int m;
            try
            {
                m = int.Parse(textBox14.Text);
            }
            catch
            {
                m = 10;
            }

            Random rand1 = new Random();
            int p = Prost_Ch((rand1.Next() % (int.Parse(Math.Pow(10, 6).ToString()) - int.Parse(Math.Pow(10, 3).ToString())) + int.Parse(Math.Pow(10, 3).ToString())));
            label37.Text = p.ToString();
            int Ca = Prost_Ch(rand1.Next() % (1000 - 100) + 100);        label32.Text = Ca.ToString();
            //int Ca = Calculate_d_Shamir(p - 1, p);
            label32.Text = Ca.ToString();
            //int Ca = Prost_Ch((rand1.Next() % (int.Parse(Math.Pow(10, 6).ToString()) - int.Parse(Math.Pow(10, 3).ToString())) + int.Parse(Math.Pow(10, 3).ToString())));
            int Da = Prost_Ch(Ca++);
            //int Da = Calculate_d_Shamir(p - 1, Ca);
            //int Da = Calculate_d_Shamir(Ca);                  label33.Text = Da.ToString();
            int Cb = Prost_Ch(rand1.Next() % (1000 - 100) + 100);        label34.Text = Cb.ToString();
            
            //int Cb = Calculate_d_Shamir(p - 1, Ca);
            //int Cb = Prost_Ch((rand1.Next() % (int.Parse(Math.Pow(10, 5).ToString()) - int.Parse(Math.Pow(10, 3).ToString())) + int.Parse(Math.Pow(10, 3).ToString())));
            label34.Text = Cb.ToString();
            int Db = Prost_Ch(Cb++);
            //int Db = Calculate_d_Shamir(p - 1, Cb);
            //int Db = Calculate_d_Shamir(Cd);                  label35.Text = Db.ToString();
            int x1 = step_mod(m, Ca, p); label39.Text = x1.ToString();
            int x2 = step_mod(x1, Cb, p); label41.Text = x2.ToString();
            int x3 = step_mod(x2, Da, p); label43.Text = x3.ToString();
            int x4 = step_mod(x3, Db, p); label45.Text = x4.ToString();
            textBox15.Text = x4.ToString();
        }

        public static int AlgEv(int a, int b)
        {
            int res = 0;
            while(a != 0 && b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            res = a + b;
            return res;
        }

        public static int Calculate_d_Shamir(int C, int neravno = 0)
        {
            int res = C++;
            while (true)
            {
                if ((C * step_mod(res, 1, (p - 1))) == 1)
                {
                    return res;
                }
                else
                {
                    res++;
                }

            }
            /*int prom = C += 2;
            do
            {
                prom++;
            } while ((AlgEv(prom, C) == 1 && (prom != neravno)));
*/

            return res;
            
            
        }

        public static int Prost_Ch(int min) //Поиск простого числа
        {
            int tmp = min;
            int current = 2;

            while (true)
            {
                if (tmp % current == 0)
                {
                    tmp++;
                    current = 2;
                    continue;
                }
                else
                {
                    if (current != 2)
                        current += 2;
                    else
                        current++;
                    if (current >= Math.Sqrt((double)tmp))
                        return tmp;
                }
            }
        }
    }
}
