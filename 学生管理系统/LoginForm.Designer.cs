
namespace 学生管理系统
{
    partial class LoginForm
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txt_account = new Sunny.UI.UITextBox();
            this.txt_password = new Sunny.UI.UITextBox();
            this.btn_Login = new Sunny.UI.UISymbolButton();
            this.btn_close = new Sunny.UI.UISymbolButton();
            this.btn_Regeist = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 19F);
            this.uiLabel1.Location = new System.Drawing.Point(112, 107);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(148, 44);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "账号：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 19F);
            this.uiLabel2.Location = new System.Drawing.Point(112, 202);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(137, 44);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "密码：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_account
            // 
            this.txt_account.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_account.Font = new System.Drawing.Font("微软雅黑", 19F);
            this.txt_account.Location = new System.Drawing.Point(218, 116);
            this.txt_account.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_account.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_account.Name = "txt_account";
            this.txt_account.ShowText = false;
            this.txt_account.Size = new System.Drawing.Size(226, 35);
            this.txt_account.TabIndex = 2;
            this.txt_account.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_account.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_password
            // 
            this.txt_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_password.Font = new System.Drawing.Font("微软雅黑", 19F);
            this.txt_password.Location = new System.Drawing.Point(218, 211);
            this.txt_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_password.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.ShowText = false;
            this.txt_password.Size = new System.Drawing.Size(226, 35);
            this.txt_password.TabIndex = 3;
            this.txt_password.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_password.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_Login
            // 
            this.btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Location = new System.Drawing.Point(118, 347);
            this.btn_Login.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(100, 35);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "登录";
            this.btn_Login.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.Location = new System.Drawing.Point(415, 347);
            this.btn_close.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(100, 35);
            this.btn_close.Symbol = 61453;
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "退出";
            this.btn_close.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_Regeist
            // 
            this.btn_Regeist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Regeist.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Regeist.Location = new System.Drawing.Point(261, 347);
            this.btn_Regeist.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Regeist.Name = "btn_Regeist";
            this.btn_Regeist.Size = new System.Drawing.Size(100, 35);
            this.btn_Regeist.Symbol = 61639;
            this.btn_Regeist.TabIndex = 6;
            this.btn_Regeist.Text = "注册";
            this.btn_Regeist.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Regeist.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_Regeist.Click += new System.EventHandler(this.btn_Regeist_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 525);
            this.Controls.Add(this.btn_Regeist);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_account);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txt_account;
        private Sunny.UI.UITextBox txt_password;
        private Sunny.UI.UISymbolButton btn_Login;
        private Sunny.UI.UISymbolButton btn_close;
        private Sunny.UI.UISymbolButton btn_Regeist;
    }
}