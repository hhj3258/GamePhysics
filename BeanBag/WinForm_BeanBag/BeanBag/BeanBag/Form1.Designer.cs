
namespace BeanBag
{
    partial class BeanBag
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vxTextBox = new System.Windows.Forms.TextBox();
            this.vzTextBox = new System.Windows.Forms.TextBox();
            this.btnFire = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Initial horizontal velocity, m/s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Initial vertical velocity, m/s";
            // 
            // vxTextBox
            // 
            this.vxTextBox.Location = new System.Drawing.Point(221, 43);
            this.vxTextBox.Name = "vxTextBox";
            this.vxTextBox.Size = new System.Drawing.Size(72, 21);
            this.vxTextBox.TabIndex = 2;
            this.vxTextBox.Text = "2.5";
            // 
            // vzTextBox
            // 
            this.vzTextBox.Location = new System.Drawing.Point(221, 88);
            this.vzTextBox.Name = "vzTextBox";
            this.vzTextBox.Size = new System.Drawing.Size(72, 21);
            this.vzTextBox.TabIndex = 3;
            this.vzTextBox.Text = "2.0";
            // 
            // btnFire
            // 
            this.btnFire.Location = new System.Drawing.Point(218, 134);
            this.btnFire.Name = "btnFire";
            this.btnFire.Size = new System.Drawing.Size(75, 23);
            this.btnFire.TabIndex = 4;
            this.btnFire.Text = "Fire";
            this.btnFire.UseVisualStyleBackColor = true;
            this.btnFire.Click += new System.EventHandler(this.btnFire_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(218, 181);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // BeanBag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 334);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFire);
            this.Controls.Add(this.vzTextBox);
            this.Controls.Add(this.vxTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BeanBag";
            this.Text = "BeanBag Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox vxTextBox;
        private System.Windows.Forms.TextBox vzTextBox;
        private System.Windows.Forms.Button btnFire;
        private System.Windows.Forms.Button btnReset;
    }
}

