using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Rotator : MonoBehaviour
{
    static System.Random R = new System.Random();

    private float speed;

    void Start()
    {
        this.speed = (float) R.NextDouble() * 3f;
        Debug.Log(this.speed);
    }

    void Update()
    {
        transform.Rotate(new Vector3((float)R.NextDouble() * 150, (float)R.NextDouble() * 300, (float)R.NextDouble() * 450) * Time.deltaTime * this.speed);
    }
}
