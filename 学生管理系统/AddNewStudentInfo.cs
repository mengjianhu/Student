using StudentEntity;
using StudentService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生管理系统
{
    public partial class AddNewStudentInfo : Form
    {
        public AddNewStudentInfo()
        {
            InitializeComponent();
            CenterToScreen();//窗体居中显示
            //TopMost = true;
        }


        StudentBaseInfoService studentBaseInfoService = new StudentBaseInfoService();
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            //string name = this.txt_name.Text.Trim();
            //string sex = string.Empty;
            //if (cb_sex.SelectedIndex >= 0)
            //{
            //    sex = this.cb_sex.SelectedItem.ToString();
            //}
            //string age = this.txt_age.Text.Trim();
            //string stuNum = this.txt_stuNum.Text.Trim();
            //string qqNum = this.txt_qqNum.Text.Trim();
            //string email = this.txt_email.Text.Trim();
            //string phone = this.txt_phone.Text.Trim();
            //string address = this.txt_address.Text.Trim();
            //if (string.IsNullOrEmpty(name))
            //{
            //    MessageBox.Show("请输入姓名", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (string.IsNullOrEmpty(sex))
            //{
            //    MessageBox.Show("请选择性别", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (string.IsNullOrEmpty(age))
            //{
            //    MessageBox.Show("请输入年龄", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (string.IsNullOrEmpty(stuNum))
            //{
            //    MessageBox.Show("请输入学号", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (string.IsNullOrEmpty(qqNum))
            //{
            //    MessageBox.Show("请输入QQ账号", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (string.IsNullOrEmpty(email))
            //{
            //    MessageBox.Show("请输入邮箱", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (string.IsNullOrEmpty(phone))
            //{
            //    MessageBox.Show("请输入手机号", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (string.IsNullOrEmpty(address))
            //{
            //    MessageBox.Show("请输入第地址", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (studentBaseInfoService.findByStuNum(stuNum) != null)
            //{
            //    MessageBox.Show("学号重复，请重新输入", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //StudentBaseInfo studentBaseInfo = new StudentBaseInfo()
            //{
            //    name = name,
            //    sex = sex,
            //    age = int.Parse(age),
            //    stuNum = stuNum,
            //    qqNum = qqNum,
            //    email = email,
            //    phone = phone,
            //    address = address
            //};
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //int j = 0;
            //for (int i = 6089; i < 10000; i++)
            //{
               
            //    StudentBaseInfo studentBaseInfo1 = new StudentBaseInfo()
            //    {
            //        name = "测试"+ i.ToString(),
            //        sex = "男",
            //        age = 22,
            //        stuNum = "测试学号"+i.ToString(),
            //        qqNum = "测试QQ"+i,
            //        email = "测试email"+i,
            //        phone = "测试手机" + i,
            //        address = "地址" + i,
            //    };
            //    studentBaseInfoService.add(studentBaseInfo1);
                
            //    j++;
            //}
            //stopwatch.Stop();
            //MessageBox.Show(j.ToString()+stopwatch.Elapsed.Seconds);
            //if (i > 0)
            //{
            //    MessageBox.Show("添加成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("添加失败", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}

        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
