using System;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form
    {
        delegate double Deleg1(double x);

        public Form1()
        {
            InitializeComponent();
        }

        // вычисление параметров, данные из полей
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string temp = textBox1.Text;
                double x = Convert.ToDouble(temp);
                MethodNewton(x);
                MethodPolDel(x);
            }
            catch
            {
                MessageBox.Show("Некорректный ввод!");
            }
        }

        // решение уравнения для метода Ньютона
        public double FunNewton(double x)
        {
            return Math.Cos(x) - 3 * (x + 1);
        }

        // решение производного уравнения для метода ньютона
        public double DFunNewton(double x)
        {
            return -3 - Math.Sin(x);
        }

        // решение уравнения для метода половиннго деления
        public double PolDel(double x)
        {
            return Math.Pow(x, 3) + 2 * Math.Pow(x, 2) + 3 * x + 1;
        }

        // метод ньютона
        public void MethodNewton(double x)
        {
            Deleg1 fun1 = FunNewton, fun2 = DFunNewton;
            double lastx;
            double dx = double.MaxValue;
            while (Math.Abs(dx) > 1e-15)
            {
                lastx = x;
                x -= (fun1(x) / fun2(x));
                dx = x - lastx;
                chart1.Series[0].Points.AddXY(x, dx);
            }
            textBox2.Text = Convert.ToString(x);
        }

        // метод половинного деления
        public void MethodPolDel(double x)
        {
            Deleg1 funct = PolDel;
            double xlast = -50;
            double xto = 50;
            double dx = double.MaxValue;
            while (Math.Abs(dx) > 1e-15)
            {
                x = (xto + xlast) / 2;
                if (funct(xto) * funct(x) < 0)
                    xlast = x;
                else if (funct(xto) * funct(x) == 0)
                    break;
                else
                    xto = x;
                dx = xto - xlast;
                chart2.Series[0].Points.AddXY(x, dx);
            }
            textBox4.Text = Convert.ToString(x);
        }
    }
}
