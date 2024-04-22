using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotaionSpeed = 60f;
    void Update()
    {
        transform.Rotate(0f, rotaionSpeed * Time.deltaTime, 0f);
    }
}
