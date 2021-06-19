using System;

class SpringODE : ODE
{
    private double mass;    // 스프링 끝의 무게
    private double mu;  // 댐핑 계수
    private double k;   // 스프링 상수
    private double x0;  // 초기 스프링 편향(위치)

    //SpringODE 생성자: ODE 생성자를 호출함
    public SpringODE(double mass, double mu, double k, double x0) : base(2) // 스프링 운동은 2차 ODE임
    {
        this.mass = mass;
        this.mu = mu;
        this.k = k;
        this.x0 = x0;

        // 종속 변수들의 초기 상태 세팅
        // q[0]=vx : 속도
        // q[1]=x : 위치
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

    // 아래 Get 메소드들은 ODE solver에서 계산된 스프링의 위치와 속도를 반환함
    public double GetVx() { return GetQ(0); }   //종속 변수 1

    public double GetX() { return GetQ(1); }    //종속 변수 2

    public double GetTime() { return this.S; }  //독립 변수 1: ODE 클래스의 S

    // 이 메소드는 운동 방정식을 적분하기 위해 4차 Runge-Kutta 솔버를 사용하며 스프링의 속도와 위치를 업데이트함
    public void UpdatePositionAndVelocity(double dt)
    {
        ODESolver.RungeKutta4(this, dt);    // this : SpringODE가 ODE를 상속받았으므로 SpringODE를 인자로 넣어줌
    }


    // 두 개의 1차 감쇠 스프링 ODE의 우측 항 반환
    // q[0] = vx
    // q[1] = x
    // dq[0] = dvx = dt * (-mu * dx/dt - k * x) / mass
    // dq[1] = dx = dt * vx
    public override double[] GetRightHandSide(double s, double[] q, double[] deltaQ, double ds, double qScale)
    {
        double[] dq = new double[4];        // 우측 항 값들
        double[] newQ = new double[4];    // 중간 종속 변수 값들

        // 종속 변수들의 중간 값들을 계산
        for(int i = 0; i < 2; ++i)
        {
            newQ[i] = q[i] + qScale * deltaQ[i];
            //Console.WriteLine("deltaQ " + i + ": " + deltaQ[i]);
        }

        // 우측 항 값들 계산
        double G = -9.81;   //중력가속도
        dq[0] = ds * G - ds * (mu * newQ[0] + k * newQ[1]) / mass;  //
        dq[1] = ds * (newQ[0]);

        return dq;
    }
}

