using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfGame_2 : MonoBehaviour
{
    private DragProjectile golfball;

    [Header("XÃà")]
    public float vx0 = 31f;
    public float x0;

    [Header("YÃà")]
    public float vy0 = 0f;
    public float y0;

    [Header("ZÃà")]
    public float vz0 = 35f;
    public float z0;

    public float mass = 0.0459f;
    public float area = 0.001432f;
    public float density = 1.225f;
    public float cd = 0.25f;

    private void Start()
    {
        golfball = new DragProjectile(0.0, 0.0, 0.0, vx0, vy0, vz0, 0.0, mass, area, density, cd);
    }

    private void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;
        golfball.UpdateLocationAndVelocity(dt);

        float X = (float)golfball.GetX();
        float Y = (float)golfball.GetZ();
        float Z = (float)golfball.GetY();

        if (transform.position.y >= 0f)
        {
            transform.position = new Vector3(X, Y, Z);
        }
    }
}
