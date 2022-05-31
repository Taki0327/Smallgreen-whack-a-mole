using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mouse
{
    public partial class 打地鼠 : Form
    {
        public 打地鼠()
        {
            InitializeComponent();
        }
        public void SetCursor(Bitmap cursor, Point hotPoint)
        {
            int hotX = hotPoint.X;
            int hotY = hotPoint.Y;
            Bitmap myNewCursor = new Bitmap(cursor.Width * 2 - hotX, cursor.Height * 2 - hotY);
            Graphics g = Graphics.FromImage(myNewCursor);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.DrawImage(cursor, cursor.Width - hotX, cursor.Height - hotY, cursor.Width,
            cursor.Height);
            this.Cursor = new Cursor(myNewCursor.GetHicon());
            g.Dispose();
            myNewCursor.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("玩之前记得先 选择时间 再 开始游戏！\n\n*速度设置不是必选项 可根据需要调整","温馨提示");
            if (File.Exists("我是可爱的鼠标君.png"))
            {
                Bitmap a = (Bitmap)Bitmap.FromFile("我是可爱的鼠标君.png");
                int width = a.Width;
                int height = a.Height;
                if (width > 100 || height > 100)
                {
                    DialogResult ad = MessageBox.Show("检测到所使用的鼠标图标大小为："+width+"*"+height+"\n\n是否继续使用?\n\n*图片过大可能导致无法加载 不推荐使用\n*建议使用100*100及以下大小", "警告", MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
                    if (ad == DialogResult.OK)
                    {
                        SetCursor(a, new Point(0, 0));
                    }
                    else
                    {
                        MessageBox.Show("本次将使用普通鼠标图像 请注意及时更换！\n\n*如果不需要请无视本消息","Tips",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    SetCursor(a, new Point(0, 0));
                }
            }
            else
            {
                MessageBox.Show("目录中未发现图标文件\n请改名后放入本程序同一目录下\n格式为：我是可爱的鼠标君.png\n\n*本次将使用默认鼠标模式", "鼠标图标开启失败",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }
        //定义公共变量
        int sudu = 1000;
        int time;
        int min;
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择正确的游戏时间", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                DialogResult a= MessageBox.Show("是否重新开始游戏？","Tips",MessageBoxButtons.OKCancel);
                if (a == DialogResult.OK)
                {
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    timer3.Enabled = false;
                    pictureBox10.Visible = false;
                    pictureBox11.Visible = false;
                    pictureBox12.Visible = false;
                    pictureBox13.Visible = false;
                    pictureBox14.Visible = false;
                    pictureBox15.Visible = false;
                    pictureBox16.Visible = false;
                    pictureBox17.Visible = false;
                    pictureBox18.Visible = false;
                    button1.Text = "重新开始";
                    dienum = 0;
                    hitnum = 0;
                    label6.Text = "0";
                    label4.Text = "0";
                    label2.Text = "游戏已停止";
                    label9.Text = "游戏已停止";
                }
                else
                {
                    timer1.Enabled = true;
                    timer2.Enabled = true;
                    timer3.Enabled = true;
                }
            }
            else if (timer1.Enabled == false)
            {
                hitnum = 0;
                label4.Text = "0";
                timer1.Enabled = true;
                timer2.Enabled = true;
                button1.Text = "游戏进行中... 点击中止";
                timer3.Enabled = true;
                switch (comboBox1.SelectedIndex)
                {
                    case 0: time = 10; break;
                    case 1: time = 20; break;
                    case 2: time = 30; break;
                    case 3: time = 60; break;
                    case 4: time = 300; break;
                    case 5: time = 600; break;
                    case 6: time = 3600; break;
                }
                min = time;
                progressBar1.Maximum = time;
            }
            
            switch (comboBox2.SelectedIndex)
            {
                case 0: sudu = 1000; break;
                case 1: sudu = 750; break;
                case 2: sudu = 500; break;
                case 3: sudu = 300; break;
                case 4: sudu = 100; break;
            }
            timer1.Interval = sudu;
            timer2.Interval = sudu;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Random num = new Random();
            int n = num.Next(10, 19);
            int m = n - 9;
            label9.Text = m.ToString();
            //if (n == 10)
            //{
            //    pictureBox10.Visible = true;
            //}
            //if (n == 11)
            //{
            //    pictureBox11.Visible = true;
            //}
            //if (n == 12)
            //{
            //    pictureBox12.Visible = true;
            //}
            //if (n == 13)
            //{
            //    pictureBox13.Visible = true;
            //}
            //if (n == 14)
            //{
            //    pictureBox14.Visible = true;
            //}
            //if (n == 15)
            //{
            //    pictureBox15.Visible = true;
            //}
            //if (n == 16)
            //{
            //    pictureBox16.Visible = true;
            //}
            //if (n == 17)
            //{
            //    pictureBox17.Visible = true;
            //}
            //if (n == 18)
            //{
            //    pictureBox18.Visible = true;
            //}
            switch (n)
            {
                case 10: pictureBox10.Visible = true; break;
                case 11: pictureBox11.Visible = true; break;
                case 12: pictureBox12.Visible = true; break;
                case 13: pictureBox13.Visible = true; break;
                case 14: pictureBox14.Visible = true; break;
                case 15: pictureBox15.Visible = true; break;
                case 16: pictureBox16.Visible = true; break;
                case 17: pictureBox17.Visible = true; break;
                case 18: pictureBox18.Visible = true; break;
               
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

             if (pictureBox10.Visible == true)
             {
                 pictureBox10.Visible = false;
             }
             if (pictureBox11.Visible == true)
             {
                 pictureBox11.Visible = false;
             }
             if (pictureBox12.Visible == true)
             {
                 pictureBox12.Visible = false;
             }
             if (pictureBox13.Visible == true)
             {
                 pictureBox13.Visible = false;
             }
             if (pictureBox14.Visible == true)
             {
                 pictureBox14.Visible = false;
             }
             if (pictureBox15.Visible == true)
             {
                 pictureBox15.Visible = false;
             }
             if (pictureBox16.Visible == true)
             {
                 pictureBox16.Visible = false;
             }
             if (pictureBox17.Visible == true)
             {
                 pictureBox17.Visible = false;
             }
             if (pictureBox18.Visible == true)
             {
                 pictureBox18.Visible = false;
             }

             //pictureBox12.Visible = true; 
             //pictureBox13.Visible = true; 
             //pictureBox14.Visible = true;
             //pictureBox15.Visible = true; 
             //pictureBox16.Visible = true;
             //pictureBox17.Visible = true;
             //pictureBox18.Visible = true; 
        }
        int hitnum;
        int dienum;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            hitnum++;
            label4.Text = hitnum.ToString();
        }
        private void pictureBox10_MouseDown(object sender, MouseEventArgs e)
        {

            int i = int.Parse((sender as PictureBox).Name.Substring(10, 2));
            if (i == 10)
            {
                pictureBox10.Visible = false;
            }
            if (i == 11)
            {
                pictureBox11.Visible = false;
            }
            if (i == 12)
            {
                pictureBox12.Visible = false;
            }
            if (i == 13)
            {
                pictureBox13.Visible = false;
            }
            if (i == 14)
            {
                pictureBox14.Visible = false;
            }
            if (i == 15)
            {
                pictureBox15.Visible = false;
            }
            if (i == 16)
            {
                pictureBox16.Visible = false;
            }
            if (i == 17)
            {
                pictureBox17.Visible = false;
            }
            if (i == 18)
            {
                pictureBox18.Visible = false;
            }
            dienum++;
            hitnum++;
            label6.Text = dienum.ToString();
            label4.Text = hitnum.ToString();
        }
        private void timer3_Tick(object sender, EventArgs e)
        {   
            time--;
            label2.Text = time.ToString();
            progressBar1.Value = time;
            if (time == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;  
                pictureBox10.Visible = false;
                pictureBox11.Visible = false;
                pictureBox12.Visible = false;
                pictureBox13.Visible = false;
                pictureBox14.Visible = false;
                pictureBox15.Visible = false;
                pictureBox16.Visible = false;
                pictureBox17.Visible = false;
                pictureBox18.Visible = false;
                label9.Text = "游戏已停止";
                button1.Text = "重新开始";
                if (dienum == 0)
                {
                    if (hitnum == 0)
                    {
                        MessageBox.Show("你是假的人", "程序自动关闭", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Environment.Exit(0);
                    }
                }
                double percent = Math.Round(dienum * 1.00 / hitnum * 1.00, 2);
                string c = percent.ToString("p");
                double d = Math.Round(dienum * 1.00 /min * 1.00, 2);
                //double.TryParse(c, out a);
                string b = "啧啧啧";
                if (percent == 1 && d >= 0.85)
                {
                    b = "少年你好棒！";
                }
                else if (percent >= 0.6 && d >= 0.6)
                {
                    b = "少年继续加油！";
                }
                else if (percent <= 0.5 || d <= 0.3)
                {
                    b = "少年你好辣鸡！";
                }
                MessageBox.Show("恭喜你成功完成了速度为 "+sudu+"ms 的挑战！"+ "\n\n你在 " + min+" s 的游戏时间内"+"\n鼠标共点击 "+hitnum+" 次"+" 成功打中地鼠 "+dienum+" 次"+"\n你的命中率为："+ c+"\n\n"+b,"游戏结束");
                dienum = 0;
                hitnum = 0;
                label6.Text ="0";
                label4.Text ="0";
                min = 0;
            }
        }
    }
}
