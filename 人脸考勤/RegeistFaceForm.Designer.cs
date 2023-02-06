
namespace 人脸考勤
{
    partial class RegeistFaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegeistFaceForm));
            this.label1 = new System.Windows.Forms.Label();
            this.pic_face = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.txt_name = new Sunny.UI.UITextBox();
            this.txt_jobNum = new Sunny.UI.UITextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_face)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(161, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // pic_face
            // 
            this.pic_face.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_face.Location = new System.Drawing.Point(227, 169);
            this.pic_face.Name = "pic_face";
            this.pic_face.Size = new System.Drawing.Size(213, 236);
            this.pic_face.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_face.TabIndex = 7;
            this.pic_face.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(161, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "照片:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(161, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "工号：";
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(227, 437);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(213, 55);
            this.uiButton1.TabIndex = 12;
            this.uiButton1.Text = "注册人脸";
            this.uiButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // txt_name
            // 
            this.txt_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_name.Location = new System.Drawing.Point(224, 63);
            this.txt_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_name.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_name.Name = "txt_name";
            this.txt_name.ShowText = false;
            this.txt_name.Size = new System.Drawing.Size(213, 29);
            this.txt_name.TabIndex = 13;
            this.txt_name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_name.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_jobNum
            // 
            this.txt_jobNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_jobNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_jobNum.Location = new System.Drawing.Point(224, 109);
            this.txt_jobNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_jobNum.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_jobNum.Name = "txt_jobNum";
            this.txt_jobNum.ShowText = false;
            this.txt_jobNum.Size = new System.Drawing.Size(213, 29);
            this.txt_jobNum.TabIndex = 14;
            this.txt_jobNum.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_jobNum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // RegeistFaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(665, 565);
            this.Controls.Add(this.txt_jobNum);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pic_face);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegeistFaceForm";
            this.Text = "录入人脸";
            ((System.ComponentModel.ISupportInitialize)(this.pic_face)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_face;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UITextBox txt_name;
        private Sunny.UI.UITextBox txt_jobNum;
    }
}