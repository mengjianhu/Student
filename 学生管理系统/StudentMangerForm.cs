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
using 人脸考勤;

namespace 学生管理系统
{
    public partial class StudentMangerForm : Form
    {
        StudentBaseInfoService infoService = new StudentBaseInfoService();
        List<StudentBaseInfo> studentBaseInfos1 = null;
        public StudentMangerForm()
        {
            InitializeComponent();
            CenterToScreen();
            this.label5.Visible = false;
            this.uiDataGridView1.AutoGenerateColumns = false;
            this.uiDataGridView1.RowHeadersVisible = false;
            this.txt_page.Text = "1";
            studentBaseInfos1 = infoService.findByPage(1, 10);
            this.uiDataGridView1.DataSource = infoService.findByPage(1, 10);//默认显示第一页的数据
            this.lab_page.Text = infoService.findAllPage(10).Result.ToString();
        }
        int pageNum = 1;
        /// <summary>
        /// 根据姓名查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            StudentBaseInfoService infoService = new StudentBaseInfoService();
            if (!string.IsNullOrEmpty(this.txt_name.Text.Trim()))
            {
                this.label5.Visible = true;
                List<StudentBaseInfo> studentBaseInfos = infoService.findByName(this.txt_name.Text.Trim()).Result;
                studentBaseInfos1 = studentBaseInfos;
                this.uiDataGridView1.DataSource = studentBaseInfos;
                this.label5.Text = "共" + " " + studentBaseInfos.Count + " " + "条数据";
                this.label3.Visible = false;
                this.lab_page.Visible = false;
                this.label4.Visible = false;
            }
            else
            {
                List<StudentBaseInfo> studentBaseInfos = infoService.findByPage(int.Parse(this.txt_page.Text), 10);
                this.uiDataGridView1.DataSource = studentBaseInfos;
                studentBaseInfos1 = studentBaseInfos;
                this.label5.Visible = false;
                this.label3.Visible = true;
                this.lab_page.Visible = true;
                this.label4.Visible = true;
            }
        }
        private void btn_addNew_Click(object sender, EventArgs e)
        {
            AddNewStudentInfo addNewStudentInfo = new AddNewStudentInfo();
            addNewStudentInfo.Show();
        }

        private void StudentMangerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_on_Click(object sender, EventArgs e)
        {
            if (pageNum > 1)
            {
                pageNum--;
                this.txt_page.Text = pageNum.ToString();
            }
            else
            {
                pageNum = 1;
                this.txt_page.Text = pageNum.ToString();
            }
            StudentBaseInfoService infoService = new StudentBaseInfoService();
            studentBaseInfos1 = infoService.findByPage(int.Parse(this.txt_page.Text), 10);
            this.uiDataGridView1.DataSource = studentBaseInfos1;
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_next_Click(object sender, EventArgs e)
        {
            if (pageNum < int.Parse(this.lab_page.Text))
            {
                pageNum++;
                this.txt_page.Text = pageNum.ToString();
                StudentBaseInfoService infoService = new StudentBaseInfoService();
                studentBaseInfos1 = infoService.findByPage(int.Parse(this.txt_page.Text), 10);
                this.uiDataGridView1.DataSource = studentBaseInfos1;
            }

        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, EventArgs e)
        {
            StudentBaseInfoService infoService = new StudentBaseInfoService();
            this.lab_page.Text = infoService.findAllPage(10).Result.ToString();
            List<StudentBaseInfo> studentBaseInfos = infoService.findByPage(int.Parse(this.txt_page.Text), 10);
            this.uiDataGridView1.DataSource = studentBaseInfos;
            studentBaseInfos1 = studentBaseInfos;
            this.txt_name.Text = "";
        }
        /// <summary>
        /// 单元格双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.uiDataGridView1.DataSource != null)
            {
                string ss = uiDataGridView1.CurrentRow.Cells[3].Value.ToString();


                IEnumerable<StudentBaseInfo> info = (from m in studentBaseInfos1
                                                     where m.stuNum == ss
                                                     select m);
                DetailUserInfoForm detailUserInfoForm = new DetailUserInfoForm(info.ToList()[0]);
                detailUserInfoForm.Show();


            }
        }
        /// <summary>
        /// 跳转到某页数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_skip_Click(object sender, EventArgs e)
        {
            StudentBaseInfoService infoService = new StudentBaseInfoService();
            List<StudentBaseInfo> studentBaseInfos = infoService.findByPage(int.Parse(this.txt_page.Text), 10);
            this.uiDataGridView1.DataSource = studentBaseInfos;
            studentBaseInfos1 = studentBaseInfos;
        }
        /// <summary>
        /// 禁止单元格编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiDataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            Form1 ff = new Form1();
            ff.Show();
        }
    }
}
