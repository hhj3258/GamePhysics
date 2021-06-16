using System;

public abstract class ODE
{
    private int numEqns;    // number of Equations : 1�� ODE �������� ����
    private double[] q;     // ���� �������� �迭
    private double s;       // ���� ����

    public ODE(int numEqns)
    {
        this.numEqns = numEqns;     // numEqns�� �Ű����� numEqns�� �ʱ�ȭ
        this.q = new double[numEqns];   // ���� �������� �迭�� ũ�⸦ numEqns�� ũ��� �ʱ�ȭ
    }

    public int NumEqns
    {
        get { return numEqns; }
    }

    public double S
    {
        get { return s; }
        set { s = value; }
    }

    // q �迭 �� Ư�� �ε����� ���� ������ ����
    public double GetQ(int index)
    {
        return q[index];
    }

    public void SetQ(double value, int index)
    {
        q[index] = value;
        return;
    }

    // q �迭�� ����
    public double[] GetAllQ()
    {
        return q;
    }

    /// <summary>
    /// ODE�� ���� ���� ����� �� ��� �� ������ ���� �޼ҵ�,
    /// �ذ��ϰ��� �ϴ� ODE�� �´� �޼ҵ带 override�� ���� ���� �ʿ�
    /// </summary>
    /// <param name="s"> �������� </param>
    /// <param name="q"> ���� �������� �迭 </param>
    /// <param name="deltaQ"> ���� ������ ���� ��ȭ�� </param>
    /// <param name="ds"> ���� ������ ���� ��ȭ�� </param>
    /// <param name="qScale"> </param>
    public abstract double[] GetRightHandSide(double s, double[] q, double[] deltaQ, double ds, double qScale);

    
}
