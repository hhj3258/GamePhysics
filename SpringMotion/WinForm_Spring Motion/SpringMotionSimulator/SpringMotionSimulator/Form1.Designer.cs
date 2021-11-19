
namespace SpringMotionSimulator
{
    partial class SpringSimulator
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
            this.massTextBox = new System.Windows.Forms.TextBox();
            this.massLabel = new System.Windows.Forms.Label();
            this.muLabel = new System.Windows.Forms.Label();
            this.muTextBox = new System.Windows.Forms.TextBox();
            this.kLabel = new System.Windows.Forms.Label();
            this.kTextBox = new System.Windows.Forms.TextBox();
            this.x0Label = new System.Windows.Forms.Label();
            this.x0TextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // massTextBox
            // 
            this.massTextBox.Location = new System.Drawing.Point(166, 39);
            this.massTextBox.Name = "massTextBox";
            this.massTextBox.Size = new System.Drawing.Size(100, 21);
            this.massTextBox.TabIndex = 0;
            this.massTextBox.Text = "1.0";
            // 
            // massLabel
            // 
            this.massLabel.AutoSize = true;
            this.massLabel.Location = new System.Drawing.Point(76, 42);
            this.massLabel.Name = "massLabel";
            this.massLabel.Size = new System.Drawing.Size(84, 12);
            this.massLabel.TabIndex = 1;
            this.massLabel.Text = "End mass, kg";
            // 
            // muLabel
            // 
            this.muLabel.AutoSize = true;
            this.muLabel.Location = new System.Drawing.Point(10, 69);
            this.muLabel.Name = "muLabel";
            this.muLabel.Size = new System.Drawing.Size(150, 12);
            this.muLabel.TabIndex = 3;
            this.muLabel.Text = "Damping coefficient, kg/s";
            // 
            // muTextBox
            // 
            this.muTextBox.Location = new System.Drawing.Point(166, 66);
            this.muTextBox.Name = "muTextBox";
            this.muTextBox.Size = new System.Drawing.Size(100, 21);
            this.muTextBox.TabIndex = 2;
            this.muTextBox.Text = "1.5";
            // 
            // kLabel
            // 
            this.kLabel.AutoSize = true;
            this.kLabel.Location = new System.Drawing.Point(33, 96);
            this.kLabel.Name = "kLabel";
            this.kLabel.Size = new System.Drawing.Size(127, 12);
            this.kLabel.TabIndex = 5;
            this.kLabel.Text = "Spring constant, N/m";
            // 
            // kTextBox
            // 
            this.kTextBox.Location = new System.Drawing.Point(166, 93);
            this.kTextBox.Name = "kTextBox";
            this.kTextBox.Size = new System.Drawing.Size(100, 21);
            this.kTextBox.TabIndex = 4;
            this.kTextBox.Text = "20.0";
            // 
            // x0Label
            // 
            this.x0Label.AutoSize = true;
            this.x0Label.Location = new System.Drawing.Point(59, 123);
            this.x0Label.Name = "x0Label";
            this.x0Label.Size = new System.Drawing.Size(101, 12);
            this.x0Label.TabIndex = 7;
            this.x0Label.Text = "Initial location, m";
            // 
            // x0TextBox
            // 
            this.x0TextBox.Location = new System.Drawing.Point(166, 120);
            this.x0TextBox.Name = "x0TextBox";
            this.x0TextBox.Size = new System.Drawing.Size(100, 21);
            this.x0TextBox.TabIndex = 6;
            this.x0TextBox.Text = "-0.2";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(191, 162);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(191, 201);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // SpringSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 450);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.x0Label);
            this.Controls.Add(this.x0TextBox);
            this.Controls.Add(this.kLabel);
            this.Controls.Add(this.kTextBox);
            this.Controls.Add(this.muLabel);
            this.Controls.Add(this.muTextBox);
            this.Controls.Add(this.massLabel);
            this.Controls.Add(this.massTextBox);
            this.Name = "SpringSimulator";
            this.Text = "Spring Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox massTextBox;
        private System.Windows.Forms.Label massLabel;
        private System.Windows.Forms.Label muLabel;
        private System.Windows.Forms.TextBox muTextBox;
        private System.Windows.Forms.Label kLabel;
        private System.Windows.Forms.TextBox kTextBox;
        private System.Windows.Forms.Label x0Label;
        private System.Windows.Forms.TextBox x0TextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button resetButton;
    }
}

