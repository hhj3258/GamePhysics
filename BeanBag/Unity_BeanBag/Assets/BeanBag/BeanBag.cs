using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBag : MonoBehaviour
{
    [Header("초기 속도")]
    [SerializeField] float vx0; //초기 수평 속도
    [SerializeField] float vy0; // 초기 수직 속도

    [Header("초기 위치")]
    [SerializeField] float x0; //초기 수평 위치
    [SerializeField] private float y0; // 빈백의 초기 높이

    [Header("X, Z, Time")]
    [SerializeField] float x; // 수평 위치
    [SerializeField] private float y;   // 빈백의 높이
    [SerializeField] float t; //시간

    float g = -9.81f;  //중력 가속도

    bool isStart=false;

    private void Update()
    {
        if(isStart)
        {
            t += Time.deltaTime;

            //x축(수평) 위치 변화 방정식 = 초기 x위치+초기 x속도 * t
            x = x0 + vx0 * t;

            //y축(수직) 위치 변화 방정식 = 초기 y위치 + 초기 y속도 * t + 1/2gt^2
            y = y0 + vy0 * t + 0.5f * g * (t * t);

            transform.position = new Vector3(x, y, 0f);
        }

        if(transform.position.y <= 0f)
        {
            isStart = false;
        }
    }

    public void OnClickBtn()
    {
        isStart = true;
    }

    public void OnClickReset()
    {
        t = 0f;
        x = 0f;
        y = 0f;
        transform.position = new Vector3(x0, y0, 0f);
        isStart = false;
    }
}
