using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SpringODE : ODE
{
    private double mass;    // ������ ���� ����
    private double mu;  // ���� ���
    private double k;   // ������ ���
    private double x0;  // �ʱ� ������ ����(��ġ)

    //SpringODE ������: ODE �����ڸ� ȣ����
    public SpringODE(double mass, double mu, double k, double x0) : base(2) // ������ ��� 2���� 1�� ODE��
    {
        this.mass = mass;
        this.mu = mu;
        this.k = k;
        this.x0 = x0;

        // ���� �������� �ʱ� ���� ����
        // q[0]=vx : �ӵ�
        // q[1]=x : ��ġ
        SetQ(0.0, 0);
        SetQ(x0, 1);
    }

    public double Mu
    {
        get { return mu; }
        set { mu = value; }
    }

    public double Mass
    {
        get { return mass; }
        set { mass = value; }
    }

    public double K
    {
        get { return k; }
        set { k = value; }
    }

    public double X0
    {
        get { return x0; }
        set { x0 = value; }
    }

    // �Ʒ� Get �޼ҵ���� ODE solver���� ���� �������� ��ġ�� �ӵ��� ��ȯ��
    public double GetVx() { return GetQ(0); }   //���� ���� 1

    public double GetX() { return GetQ(1); }    //���� ���� 2

    public double GetTime() { return this.S; }  //���� ���� 1: ODE Ŭ������ S

    // �� �޼ҵ�� � �������� �����ϱ� ���� 4�� Runge-Kutta �ֹ��� ����ϸ� �������� �ӵ��� ��ġ�� ������Ʈ��
    public void UpdatePositionAndVelocity(double dt)
    {
        ODESolver.RungeKutta4(this, dt);    // this : SpringODE�� ODE�� ��ӹ޾����Ƿ� SpringODE�� ���ڷ� �־���
    }


    // �� ���� 1�� ���� ������ ODE�� ���� �� ��ȯ
    // q[0] = vx
    // q[1] = x
    // dq[0] = dvx = dt * (-mu * dx/dt - k * x) / mass
    // dq[1] = dx = dt * vx
    public override double[] GetRightHandSide(double s, double[] q, double[] deltaQ, double ds, double qScale)
    {
        double[] dq = new double[4];        // ���� �� ����
        double[] newQ = new double[4];    // �߰� ���� ���� ����

        // ���� �������� �߰� ������ ���
        for (int i = 0; i < 2; ++i)
        {
            newQ[i] = q[i] + qScale * deltaQ[i];
            //Console.WriteLine("deltaQ " + i + ": " + deltaQ[i]);
        }
        //Console.WriteLine("ds: " + ds);
        // ���� �� ���� ���
        double G = -9.81;   //�߷°��ӵ�

        // dv = - dt * a
        dq[0] = - ds * (mu * newQ[0] + k * newQ[1]) / mass;
        // dx = - dt * v
        dq[1] = ds * (newQ[0]);

        return dq;
    }
}