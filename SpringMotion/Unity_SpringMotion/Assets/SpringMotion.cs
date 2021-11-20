using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpringMotion : MonoBehaviour
{
    [SerializeField] private float mass = 1f;    // 스프링 끝의 무게
    [SerializeField] private float mu = 1.5f;  // 댐핑 계수
    [SerializeField] private float k = 20f;   // 스프링 상수
    [SerializeField] private float x0 = -0.2f;  // 초기 스프링 편향(위치)
    [SerializeField] float v0 = 0f;
    float sum_time = 0f;

    float sum_force = 0f;
    bool isPress = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);

        if (Input.GetKey(KeyCode.S))
        {
            isPress = true;
            sum_force = 0.01f;
            transform.position -= new Vector3(0f, sum_force, 0f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            isPress = true;
            sum_force = 0.01f;
            transform.position += new Vector3(0f, sum_force, 0f);
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            x0 = transform.position.y;
            v0 = 0f;
            isPress = false;
        }
    }

    private void FixedUpdate()
    {
        if (isPress == false)
            RK4();
    }

    float func_a(float v, float x)
    {
        float a = -(mu * v + k * x) / mass;
        return a;
    }

    void RK4()
    {
        float dt = Time.fixedDeltaTime;
        sum_time += dt;

        float dv1 = func_a(v0, x0) * dt;
        float dx1 = v0 * dt;

        float dv2 = func_a(v0 + dv1 / 2f, x0 + dx1 / 2f) * dt;
        float dx2 = (v0 + dv1 / 2f) * dt;

        float dv3 = func_a(v0 + dv2 / 2f, x0 + dx2 / 2f) * dt;
        float dx3 = (v0 + dv2 / 2f) * dt;

        float dv4 = func_a(v0 + dv3, x0 + dx3) * dt;
        float dx4 = (v0 + dv3) * dt;

        v0 = v0 + 1f / 6f * (dv1 + 2f * dv2 + 2f * dv3 + dv4);
        x0 = x0 + 1f / 6f * (dx1 + 2f * dx2 + 2f * dx3 + dx4);

        //transform.position = new Vector3(transform.position.x, x0, transform.position.z);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(transform.position.x, v0, transform.position.z);

        if (sum_time <= 1f)
            //Debug.Log("t: " + sum_time  + "\tv: " + v0 + "\tx: " + x0);
            Debug.Log(sum_time + "\t" + v0 + "\t" + x0);
    }
}
