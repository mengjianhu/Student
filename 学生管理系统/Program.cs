using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace 学生管理系统
{
    static class Program
    {
        static SpeechSynthesizer speech = new SpeechSynthesizer();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //speak("欢迎使用本系统");
            //string DD = DateTime.Now.ToString("yyyy-MM-dd");
            Application.Run(new LoginForm());
        }
        /// <summary>
        /// 语音播报
        /// </summary>
        /// <param name="msg"></param>
        public static void speak(string msg)
        {
            speech.SpeakAsyncCancelAll();//停止没有播放完成的语音
            speech.SpeakAsync(msg);//播放语音
        }
    }
}
