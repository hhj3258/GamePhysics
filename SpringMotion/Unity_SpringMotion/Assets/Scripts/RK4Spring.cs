using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RK4Spring : MonoBehaviour
{
    [SerializeField] double mass = 1.0d;  //1kg
    [SerializeField] double mu = 1.5d;    //1.5 N-s/m
    [SerializeField] double k = 20.0d;    //20 N/m
    [SerializeField] double x0 = -0.2d;

    SpringODE springODE;

    void MainMethod()
    {
        SpringODE ode = new SpringODE(mass, mu, k, x0);

        //7초까지 0.1초마다 업데이트
        double dt = 0.1d;

        //Console.WriteLine("t           x         v");
        //Console.WriteLine((float)ode.GetTime() + "            " + (float)ode.GetX() + "          " + (float)ode.GetVx());
        Debug.Log("t           x         v");
        Debug.Log((float)ode.GetTime() + "            " + (float)ode.GetX() + "          " + (float)ode.GetVx());

        

        while (ode.GetTime() <= 7.0)
        {
            ode.UpdatePositionAndVelocity(dt);
            // Console.WriteLine((float)ode.GetTime() + "           " + (float)ode.GetX() + "          " + (float)ode.GetVx());
            Debug.Log((float)ode.GetTime() + "           " + (float)ode.GetX() + "          " + (float)ode.GetVx());

            //transform.position = new Vector3(transform.position.x, (float)ode.GetX(), transform.position.z);
        }

        return;
    }

    private void Start()
    {
        MainMethod();
        springODE = new SpringODE(mass, mu, k, x0);
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        springODE.UpdatePositionAndVelocity(dt);

        transform.position = new Vector3(transform.position.x, (float)springODE.GetX(), transform.position.z);
    }
}
