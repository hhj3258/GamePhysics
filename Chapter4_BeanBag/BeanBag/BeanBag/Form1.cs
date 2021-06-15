using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeanBag
{
    public partial class BeanBag : Form
    {
        private Panel drawingPanel;

        private Image playerIcon;

        // 게임의 스피드를 컨트롤 할 때 사용함
        private Timer gameTimer;

        private double z;   // 빈백의 높이
        private double z0; // 빈백의 초기 높이
        double vz0; // 초기 수직 속도
        double x; // 수평 위치
        double x0; //초기 수평 위치
        double vx0; //초기 수평 속도
        double time; //시간


        public BeanBag()
        {
            z = 1.7d;
            z0 = 1.7d;
            vz0 = 0d;
            x = 0.5d;
            x0 = 0.5d;
            vx0 = 0d;
            time = 0d;

            playerIcon = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\BeanBagTosser.jpg");   // 플레이어 이미지

            // 작업 속도를 늦출 타이머 생성
            gameTimer = new Timer();
            gameTimer.Interval = 50;    //0.05초 마다 실행
            gameTimer.Tick += new EventHandler(ActionPerformed);

            //드로잉 패널
            drawingPanel = new Panel();
            drawingPanel.Width = 251;
            drawingPanel.Height = 151;
            drawingPanel.Left = 350;
            drawingPanel.Top = 50;
            drawingPanel.BorderStyle = BorderStyle.FixedSingle;

            this.Controls.Add(drawingPanel);

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Visible = true;

            UpdateDisplay();


            InitializeComponent();
        }


        //GUI를 다시 그려줌
        private void UpdateDisplay()
        {
            Graphics g = drawingPanel.CreateGraphics();
            int width = drawingPanel.Width - 1;
            int height = drawingPanel.Height - 1;

            //  Clear the current display.
            g.Clear(drawingPanel.BackColor);

            //  Draw the beanbag tosser.
            int zLocation = 125 - 67;
            g.DrawImage(playerIcon, 7, zLocation, 51, 67);

            Pen blackPen = new Pen(Color.Black, 2);
            g.DrawLine(blackPen, 0, 125, width, 125);
            g.DrawLine(blackPen, 150, 125, 150, height);
            g.DrawLine(blackPen, 175, 125, 175, height);
            g.DrawLine(blackPen, 200, 125, 200, height);
            g.DrawLine(blackPen, 225, 125, 225, height);

            SolidBrush brush = new SolidBrush(Color.Black);
            Font font = new Font("Arial", 12);
            g.DrawString("10", font, brush, 152, 127);
            g.DrawString("20", font, brush, 177, 127);
            g.DrawString("50", font, brush, 202, 127);
            g.DrawString("0", font, brush, 227, 127);

            //  Update the position of the beanbag on the screen.
            int xPosition = (int)(100.0 * x);
            double deltaZ = z - 1.25;
            int zPosition = (int)(125 - 100.0 * deltaZ);
            g.FillEllipse(brush, xPosition, zPosition, 10, 10);

            //  Clean up the Graphics object.
            g.Dispose();
        }

        //0.05초마다 타이머에 의해 호출됨
        private void ActionPerformed(object sender, EventArgs e)
        {
            //시간 업데이트, 빈백의 포지션 계산
            double timeIncrement = 0.05d;
            time += timeIncrement;

            //x축(수평) 위치 변화 방정식 = 초기 x위치+초기 x속도 * t
            x = x0 + vx0 * time;

            double g = -9.81d;  //중력 가속도

            //z축(수직) 위치 변화 방정식 = 초기 z위치 + 초기 z속도 * t + 1/2gt^2
            z = z0 + vz0 * time + 0.5 * g * time * time;

            UpdateDisplay();

            //바닥 zPos=1.4
            if (z <= 1.4)
            {
                gameTimer.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //게임 시작
        private void btnFire_Click(object sender, EventArgs e)
        {
            vx0 = Convert.ToDouble(vxTextBox.Text); // x축 초기 속도
            vz0 = Convert.ToDouble(vzTextBox.Text); // z축 초기 속도

            gameTimer.Start();
        }

        //게임 리셋
        private void btnReset_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();

            //변수들 초기 값으로 리셋
            z = 1.7d;
            z0 = 1.7d;
            vz0 = 0d;
            x = 0.5d;
            x0 = 0.5d;
            vx0 = 0d;
            time = 0d;

            UpdateDisplay();
        }


    }
}
