using System;
using UnityEngine;

public class Satelite : MonoBehaviour
{
    public float rotationSpeed;
    public float revolvingSpeed;
    public Transform revolvingCenter;
    public Vector3 revolvingAxis;


    void Start()
    {
        Rotate(360 * UnityEngine.Random.value);
        Revolve(360 * UnityEngine.Random.value);
    }

    void Update()
    {
        Rotate(rotationSpeed * Time.deltaTime);

        Revolve(revolvingSpeed * Time.deltaTime);
    }

    private void Rotate(float angle)
    {
        transform.Rotate(Vector3.down, angle, Space.World);
    }

    private void Revolve(float angle)
    {
        transform.RotateAround(revolvingCenter.position, revolvingAxis, angle);
    }
}