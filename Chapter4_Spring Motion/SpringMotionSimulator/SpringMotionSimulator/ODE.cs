using System;

public abstract class ODE
{
    private int numEqns;    // number of Equations : 1차 ODE 방정식의 개수
    private double[] q;     // 종속 변수들의 배열
    private double s;       // 독립 변수

    public ODE(int numEqns)
    {
        this.numEqns = numEqns;     // numEqns를 매개변수 numEqns로 초기화
        this.q = new double[numEqns];   // 종속 변수들의 배열의 크기를 numEqns의 크기로 초기화
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

    // q 배열 중 특정 인덱스의 종속 변수만 리턴
    public double GetQ(int index)
    {
        return q[index];
    }

    public void SetQ(double value, int index)
    {
        q[index] = value;
        return;
    }

    // q 배열을 리턴
    public double[] GetAllQ()
    {
        return q;
    }

    /// <summary>
    /// ODE의 우측 항을 계산한 후 결과 값 리턴을 위한 메소드,
    /// 해결하고자 하는 ODE에 맞는 메소드를 override를 통해 구현 필요
    /// </summary>
    /// <param name="s"> 독립변수 </param>
    /// <param name="q"> 종속 변수들의 배열 </param>
    /// <param name="deltaQ"> 종속 변수의 순간 변화량 </param>
    /// <param name="ds"> 독립 변수의 순간 변화량 </param>
    /// <param name="qScale"> </param>
    public abstract double[] GetRightHandSide(double s, double[] q, double[] deltaQ, double ds, double qScale);


}

