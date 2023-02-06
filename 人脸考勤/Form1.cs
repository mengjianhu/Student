using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceMatchDll;
using System.Speech;
using System.Speech.Synthesis;
using AttendanceService;
using AttendanceEntity;
namespace 人脸考勤
{
    public partial class Form1 : Form
    {
        FaceMatch faceMatch;
        SpeechSynthesizer a;
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            CheckForIllegalCrossThreadCalls = false;
             faceMatch = new FaceMatch("CWcRRZqtBsmnyhcQLcH8ocZ5WHnz9813kdjuk4KLtBYV", "ENNwTMnAHLpRePKoTe2WUbXqjvKA7JHBPvbtcdzVJWxu", this.faceVideoPlayer, null);
            faceMatch.openDevice();
            faceMatch.FaceEvent += FaceMatch_FaceEvent;
            a= new SpeechSynthesizer();
        }
        SuccessInfoService success = new SuccessInfoService();
        private string FaceMatch_FaceEvent(float value,string name,string jobNum)
        {
            this.textBox1.Text += value+name+"===>"+DateTime.Now.ToString() + "\r\n";
            SuccessInfo successInfo = new SuccessInfo();
            successInfo.name = name;
            successInfo.jobNum = jobNum;
            successInfo.score = value;
            successInfo.datetime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
             success.add(successInfo);
            if (value>0.5)
            {
                a.SpeakAsync(name+"打卡成功");
                
                faceMatch.faceMatch = false;
            }
            else
            {
                a.SpeakAsync("打卡失败");
                faceMatch.faceMatch = false;
            }
            //else
            //{
            //    a.Speak("打卡失败");
            //}
            return "";
        }
       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            faceMatch.closeDevice();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            faceMatch.faceMatch = true;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
