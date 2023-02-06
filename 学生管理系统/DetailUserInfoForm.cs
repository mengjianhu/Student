using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentEntity;
using StudentService;
namespace 学生管理系统
{
    public partial class DetailUserInfoForm : Form
    {
        StudentBaseInfo studentBaseInfo = null;
        StudentBaseInfoService infoService = new StudentBaseInfoService();
        public DetailUserInfoForm(StudentBaseInfo studentBaseInfo)
        {
            InitializeComponent();
            CenterToScreen();
            TopMost = true;
            if (studentBaseInfo != null)
            {
                this.studentBaseInfo = studentBaseInfo;
                this.txt_name.Text = studentBaseInfo.name;
                this.txt_xb.Text = studentBaseInfo.sex;
                this.txt_age.Text = studentBaseInfo.age.ToString();
                this.txt_stuNum.Text = studentBaseInfo.stuNum;
                this.txt_qqNum.Text = studentBaseInfo.qqNum;
                this.txt_email.Text = studentBaseInfo.email;
                this.txt_phone.Text = studentBaseInfo.phone;
                this.txt_address.Text = studentBaseInfo.address;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (this.studentBaseInfo != null)
            {
                StudentBaseInfo info = this.studentBaseInfo;
                info.name = this.txt_name.Text;
                info.sex = this.txt_xb.Text;
                info.age = int.Parse(this.txt_age.Text.Trim());
                studentBaseInfo.stuNum = this.txt_stuNum.Text;
                studentBaseInfo.qqNum = this.txt_qqNum.Text;
                studentBaseInfo.email = this.txt_email.Text;
                studentBaseInfo.phone = this.txt_phone.Text;
                studentBaseInfo.address = this.txt_address.Text;
                if (infoService.update(info).Result > 0)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (this.studentBaseInfo != null)
            {
                int i = infoService.del(studentBaseInfo.stuNum).Result;
                if (i > 0)
                {
                    MessageBox.Show("删除成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }

        }
    }
}
