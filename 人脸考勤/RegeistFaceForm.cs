using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DreamHelper;
using AttendanceEntity;
using AttendanceService;
using System.IO;

namespace 人脸考勤
{
    public partial class RegeistFaceForm : Form
    {
        public RegeistFaceForm()
        {
            InitializeComponent();
            CenterToScreen();
         
        }
        EmployerService service = new EmployerService();
       
      
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txt_name.Text))
            {
                MessageBox.Show("请输入员工的姓名", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ( string.IsNullOrEmpty(this.txt_jobNum.Text))
            {
                MessageBox.Show("请输入员工的工号", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择图片";
            openFileDialog.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.png";
            openFileDialog.Multiselect = false;
            openFileDialog.FileName = string.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                if (string.IsNullOrEmpty(path))
                {
                    return;
                }
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    this.pic_face.Image = Image.FromStream(fs);
                }
                if (this.txt_jobNum.Text == "")
                {
                    return;
                }
                if (service.findwithJobNum(txt_jobNum.Text) != null)//根据工号查询信息
                {
                    MessageBox.Show("已经注册");
                    return;
                }
                string base64 = Base64Helper.FileToBase64Str(path);
                Employeer employeer = new Employeer();
                employeer.name = this.txt_name.Text;
                employeer.jobNum = this.txt_jobNum.Text.Trim();
                employeer.imageFace = base64;
                if (service.add(employeer) > 0)
                {
                    MessageBox.Show("注册成功");
                    this.txt_name.Text = "";
                    this.txt_jobNum.Text = "";
                    this.pic_face.Image = null;
                }
            }
        }
    }
}
