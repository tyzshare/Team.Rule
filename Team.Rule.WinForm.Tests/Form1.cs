using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team.Rule.WinForm.Tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //JJ().Wait();
            StaticClass.dic.Add(1, "tyzshare");
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            var a = fun();
            var a1 = fun1();
            await a;
            int b = Convert.ToInt32(await a);
            await a1;

        }
        private async Task<string> fun()
        {

            int sum = 0;

            for (int i = 0; i < 1000; i++)
            {
                sum = sum + i;
            }

            return "1";
        }
        private async Task<string> fun1()
        {

            int sum = 0;

            for (int i = 0; i < 1000; i++)
            {
                sum = sum + i;
            }
            return sum.ToString();
        }

        public async Task JJ()
        {
            var reslut = fun1();
            MessageBox.Show("DD" + reslut.Result);


            //  MessageBox.Show("DD" +await reslut);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            StaticClass.dic.Add(1, "tyzshare");
            MessageBox.Show("静态类的字典添加tyzshare成功");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (StaticClass.dic.Count > 0)
            {
                MessageBox.Show(StaticClass.dic.First().Value);
            }
            else {
                MessageBox.Show("静态类的字典中没有内容");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NormalClass.dic.Add(1, "daixinkai");
            MessageBox.Show("普通类的中静态字典添加daixinkai成功");
            NormalClass n = new NormalClass();
            n.dic1.Add(1,"putong");
            MessageBox.Show("普通类的字典添加putong成功");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (NormalClass.dic.Count > 0)
            {
                MessageBox.Show(NormalClass.dic.First().Value);
            }
            else {
                MessageBox.Show("静态类的字典中没有内容");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NormalClass nor = new NormalClass();
            if (nor.dic1.Count > 0)
            {
                MessageBox.Show(nor.dic1.First().Value);
            }
            else {
                MessageBox.Show("pu类的字典中没有内容");
            }
        }
    }

    public static class StaticClass
    {
        public static Dictionary<int, string> dic = new Dictionary<int, string>();
    }


    public class NormalClass
    {
        public static Dictionary<int, string> dic = new Dictionary<int, string>();
        public Dictionary<int, string> dic1 = new Dictionary<int, string>();
    }
}
