using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfGame : MonoBehaviour
{
    float G = -9.81f;

    public float t;

    [Header("XÃà")]
    public float vx0;
    public float x0;

    [Header("YÃà")]
    public float vy0;
    public float y0;

    [Header("ZÃà")]
    public float vz0;
    public float z0;

    private void FixedUpdate()
    {
        t = Time.fixedTime;

        float x = x0 + vx0 * t;
        float z = z0 + vz0 * t;

        float vy = vy0 + G * t;
        float y = y0 + vy0 * t + (1f / 2f) * G * t * t;

        if (y >= 0f)
        {
            transform.position = new Vector3(x, y, z);

            Debug.Log("time=" + t + "      " + 
                                "x=" + x.ToString("N3") + "      " + 
                                "y=" + y.ToString("N3") + "      " + 
                                "z=" + z.ToString("N3"));
        }

    }
}
