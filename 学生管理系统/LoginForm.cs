using StudentEntity;
using StudentService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生管理系统
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            CenterToScreen();//窗体居中
        }
        LoginService loginService = new LoginService();
        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_account.Text.Trim()))
            {
                MessageBox.Show("请输入账号信息", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(this.txt_password.Text.Trim()))
            {
                MessageBox.Show("请输入账号信息", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UserLogin user = loginService.fingByAccount(this.txt_account.Text.Trim(), this.txt_password.Text.Trim()).Result;
            if (user != null)
            {
                MessageBox.Show("登录成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StudentMangerForm studentMangerForm = new StudentMangerForm();
                studentMangerForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败,账号或密码错误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Regeist_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_account.Text.Trim()))
            {
                MessageBox.Show("请输入账号信息", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(this.txt_password.Text.Trim()))
            {
                MessageBox.Show("请输入账号信息", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UserLogin user = new UserLogin();
            user.account = this.txt_account.Text.Trim();
            user.password = this.txt_password.Text.Trim();
            Task<int> TT = loginService.add(user);
            if (TT.Result > 0)
                MessageBox.Show("注册成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
