using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AiSD_lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double AnnealingMethod(double initialTemperature, double finalTemperature, double x_0) //Метод Отжига
                                                                                                     //double initialTemperature - начальное значение (максимальная температура)
                                                                                                     //double finalTemperature - конечное значение (минимальная необходимая температура)
                                                                                                     //double x0 - начальный x
        {
            double x_prom = x_0;
            double minOpt = funcF(x_0);
            for (int i = 1; funcT(initialTemperature, i) > finalTemperature ;  )
            {
                //MessageBox.Show("a");
                if (funcF(x_prom) < minOpt)
                {
                    minOpt = funcF(x_prom);
                }
                double x_i = funcG(x_prom, funcT(initialTemperature, i));
                double dF = funcF(x_i) - funcF(x_prom);

                var randDouble = new Random();
                double max = 1;
                double min = 0;
                if ( (randDouble.NextDouble() * (max - min) + min ) < proverka(dF, funcT(initialTemperature, i)))
                {
                    richTextBox1.Text += x_prom + "\t" + funcF(x_prom) + '\n';

                    /*richTextBox1.Text += x_prom + '\t' + '\n';
                    richTextBox2.Text += funcF(x_prom) + '\n';
                    richTextBox3.Text += funcT(initialTemperature, i) + '\n';*/

                    x_prom = x_i;
                    i++;
                }
            }
            return minOpt;
        }

        // Случайное распределение Коши Взято с сайта:https://habr.com/ru/post/263993/ с некоторыми необходимыми изменениями, они взяты с https://translated.turbopages.org/proxy_u/en-ru.ru.a0fc7a2e-6281981f-d3b07803-74722d776562/https/stackoverflow.com/questions/9363802/stable-distribution-random-numbers
        static double Cauchy(double min, double max)
        {
            double x1, x2, temp;
            double x0 = min + (max - min) / 2;

            var randDouble = new Random();
            int max_rand = 1;
            int min_rand = -1;
            do
            {
                x1 = (randDouble.NextDouble() * (max_rand - min_rand) + min_rand);
                x2 = (randDouble.NextDouble() * (max_rand - min_rand) + min_rand);
                temp = x0 + Math.Tan(Math.PI * (x1 / x2 - 0.5));
            } while (temp < min || temp > max);
            return temp;
        }

        
        private double proverka(double dF, double T)
        {
            if (dF < 0)
            {
                return 1;
            }
            return Math.Pow(Math.E, (-dF/T));
        }
        private double funcG(double x, double T)
        {
            Random rand = new Random();
            return x + T * Cauchy(-1, 1); //(rand.NextDouble()/rand.NextDouble());
        }
        private double funcT(double initialTemperature, double i) 
        {
            return initialTemperature / i;
        }
        private double funcF(double x)
        {
            return Math.Pow(x, 2) + 10 - 10 * Math.Cos(2 * x * Math.PI);
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            double Tmin = double.Parse(textBox3.Text);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            
            textBox1.Text = AnnealingMethod(10, Tmin, -10).ToString();
            
            stopwatch.Stop();
            textBox2.Text = stopwatch.Elapsed.TotalMilliseconds.ToString();
        }
    }
}
