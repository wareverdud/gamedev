using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    private float speed = 2.5f;
    private float rotationSpeed;
    public Vector3 cenLocal;

    public CubeMaterialChange check1;
    public CubeMaterialChange check2;
    public CubeMaterialChange check3;
    public ActivatablePlatform platform1;
    public ActivatablePlatform platform2;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        
        if(body != null)
        {
            body.freezeRotation = true;
        }
    }

    void Update()
    {
        if (check1.IsActivated() && check2.IsActivated() && check3.IsActivated()
            && platform1.IsActivated() && platform2.IsActivated())
        {
            rotationSpeed = speed;
        }
        transform.RotateAround(transform.GetChild(0).position , Vector3.up, rotationSpeed);
    }
}
