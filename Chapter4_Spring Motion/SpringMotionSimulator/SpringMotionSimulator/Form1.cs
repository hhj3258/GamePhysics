using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpringMotionSimulator
{
    public partial class SpringSimulator : Form
    {
        private Panel drawingPanel;

        //게임의 스피드를 컨트롤하기 위해 사용함
        private Timer gameTimer;

        SpringODE springODE;

        public SpringSimulator()
        {
            // 디폴트 SpringODE 객체를 생성함으로써 디스플레이에 초기값 업데이트
            springODE = new SpringODE(1.0, 0.5, 20.0, 0.4);

            // 작업 속도를 늦출 타이머 생성
            gameTimer = new Timer();
            gameTimer.Interval = 50;    //50ms 딜레이
            gameTimer.Tick += new EventHandler(ActionPerformed);

            //  Create a drawing panel.
            drawingPanel = new Panel();
            drawingPanel.Width = 151;
            drawingPanel.Height = 301;
            drawingPanel.Left = 400;
            drawingPanel.Top = 50;
            drawingPanel.BorderStyle = BorderStyle.FixedSingle;

            //  Add the GUI components to the Form
            this.Controls.Add(drawingPanel);

            //  Center the form on the screen and make
            //  it visible.
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Visible = true;

            UpdateDisplay();

            InitializeComponent();
        }

        private void UpdateDisplay()
        {
            Graphics g = drawingPanel.CreateGraphics();
            int width = drawingPanel.Width - 1;

            //  Clear the current display.
            g.Clear(drawingPanel.BackColor);

            Pen blackPen = new Pen(Color.Black, 2);
            g.DrawLine(blackPen, 0, 20, width, 20);

            //  Update the position of the box and
            //  ball on the screen.
            SolidBrush brush = new SolidBrush(Color.Black);

            int zPosition = (int)(125 - 100.0 * springODE.GetX());
            g.FillRectangle(brush, 65, zPosition, 20, 20);
            g.DrawLine(blackPen, 75, 20, 75, zPosition + 10);

            //  Clean up the Graphics object.
            g.Dispose();
        }

        private void ActionPerformed(object sender, EventArgs e)
        {
            // 스프링의 위치를 업데이트하기 위해 ODE solver 사용
            double dt = 0.05;
            springODE.UpdatePositionAndVelocity(dt);

            UpdateDisplay();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            double mass = Convert.ToDouble(massTextBox.Text);
            double mu = Convert.ToDouble(muTextBox.Text);
            double k = Convert.ToDouble(kTextBox.Text);
            double x0 = Convert.ToDouble(x0TextBox.Text);

            springODE = new SpringODE(mass, mu, k, x0);

            gameTimer.Start();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();

            double x0 = Convert.ToDouble(x0TextBox.Text);
            springODE.SetQ(x0, 1);

            UpdateDisplay();
        }
    }
}
