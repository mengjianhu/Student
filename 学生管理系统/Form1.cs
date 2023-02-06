using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
         

        }

        private void uiButton1_Click(object sender, EventArgs e)
        { 
                Program.speak("欢迎使用社区自助矫正系统，请放置身份证");
            
        }
    }
}
