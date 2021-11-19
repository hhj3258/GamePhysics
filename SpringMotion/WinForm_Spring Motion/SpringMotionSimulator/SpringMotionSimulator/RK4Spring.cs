using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpringMotionSimulator
{
    class RK4Spring
    {
        [STAThread]
        static void Main()
        {
            double mass = 1.0;  //1kg
            double mu = 1.5;    //1.5 N-s/m
            double k = 20.0;    //20 N/m
            double x0 = -0.2;

            SpringODE ode = new SpringODE(mass, mu, k, x0);

            //7초까지 0.1초마다 업데이트
            double dt = 0.1;

            Console.WriteLine("t           x         v");
            Console.WriteLine((float)ode.GetTime() + "            " + (float)ode.GetX() + "          " + (float)ode.GetVx());

            while (ode.GetTime() <= 7.0)
            {
                ode.UpdatePositionAndVelocity(dt);
                Console.WriteLine((float)ode.GetTime() + "           " + (float)ode.GetX() + "          " + (float)ode.GetVx());
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SpringSimulator());

            return;
        }
    }
}

