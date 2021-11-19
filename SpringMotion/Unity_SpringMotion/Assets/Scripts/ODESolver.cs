using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ODESolver
{
    // 4�� Runge-Kutta ODE solver
    // ���� ������ ����ϱ� ���ؼ� public static���� ����
    public static void RungeKutta4(ODE ode, double ds)
    {
        double s;   //���� ����
        double[] q; //���� ����
        double[] dq1 = new double[ode.NumEqns];
        double[] dq2 = new double[ode.NumEqns];
        double[] dq3 = new double[ode.NumEqns];
        double[] dq4 = new double[ode.NumEqns];

        //����&���� ������ ���� �� �˻��Ͽ� �Ҵ�
        s = ode.S;
        q = ode.GetAllQ();

        // getRightHandSide �޼ҵ��� ��ȯ���� 4�ܰ� ������ ���� ��Ÿ q�� �迭��
        // ds: ��Ÿ t
        // 4��° �Ű�����: ����ġ
        dq1 = ode.GetRightHandSide(s, q, q, ds, 0.0);
        dq2 = ode.GetRightHandSide(s + 0.5 * ds, q, dq1, ds, 0.5);
        dq3 = ode.GetRightHandSide(s + 0.5 * ds, q, dq2, ds, 0.5);
        dq4 = ode.GetRightHandSide(s + ds, q, dq3, ds, 1.0);

        // �� ���� ���� ��ġ���� ���� ���� �� ���� ���� ���� ������Ʈ�ϰ� ���� ODE ��ü �迭�� ������
        // �ð��� ������Ʈ ���ش�?
        ode.S = s + ds;

        for (int i = 0; i < ode.NumEqns; ++i)
        {
            q[i] = q[i] + 1.0 / 6.0 * (dq1[i] + 2.0 * dq2[i] + 2.0 * dq3[i] + dq4[i]);
            ode.SetQ(q[i], i);
        }

        return;
    }
}