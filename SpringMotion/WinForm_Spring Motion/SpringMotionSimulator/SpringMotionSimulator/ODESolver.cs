using System;

public class ODESolver
{
    // 4차 Runge-Kutta ODE solver
    // 여러 곳에서 사용하기 위해서 public static으로 선언
    public static void RungeKutta4(ODE ode, double ds)
    {
        double s;   //독립 변수
        double[] q; //종속 변수
        double[] dq1 = new double[ode.NumEqns];
        double[] dq2 = new double[ode.NumEqns];
        double[] dq3 = new double[ode.NumEqns];
        double[] dq4 = new double[ode.NumEqns];

        //종속&독립 변수의 현재 값 검색하여 할당
        s = ode.S;
        q = ode.GetAllQ();

        // getRightHandSide 메소드의 반환값은 4단계 각각에 대한 델타 q의 배열임
        // ds: 델타 t
        // 4번째 매개변수: 가중치
        dq1 = ode.GetRightHandSide(s, q, q, ds, 0.0);
        dq2 = ode.GetRightHandSide(s + 0.5 * ds, q, dq1, ds, 0.5);
        dq3 = ode.GetRightHandSide(s + 0.5 * ds, q, dq2, ds, 0.5);
        dq4 = ode.GetRightHandSide(s + ds, q, dq3, ds, 1.0);

        // 새 종속 변수 위치에서 종속 변수 및 독립 변수 값을 업데이트하고 값을 ODE 개체 배열에 저장함
        // 시간을 업데이트 해준다?
        ode.S = s + ds;
        
        for (int i = 0; i < ode.NumEqns; ++i)
        {
            q[i] = q[i] + 1.0 / 6.0 * (dq1[i] + 2.0 * dq2[i] + 2.0 * dq3[i] + dq4[i]);
            ode.SetQ(q[i], i);
        }

        return;
    }
}

