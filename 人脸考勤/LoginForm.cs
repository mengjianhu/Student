using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceEntity;
using AttendanceService;
namespace 人脸考勤
{
    public partial class LoginForm : Form
    {
        UserService userService = new UserService();
        public LoginForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            CenterToScreen();
        }
       
        private void uiButton1_Click(object sender, EventArgs e)
        {
            int i = userService.find(this.txt_account.Text, this.txt_password.Text);
            if (i > 0)
            {
                MessageBox.Show("登录成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                RegeistFaceForm regeistFaceForm = new RegeistFaceForm();
                regeistFaceForm.Show();
            }
            else
            {
               
            }

        }
    }
}
