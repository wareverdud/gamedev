using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanJump : MonoBehaviour
{
    private float force = 20f;

    public CubeMaterialChange check1;
    public CubeMaterialChange check2;
    public CubeMaterialChange check3;
    public ActivatablePlatform platform1;
    public ActivatablePlatform platform2;

    private void OnTriggerStay(Collider other)
    {
        CharacterController characterController = other.GetComponent<CharacterController>();
        if (characterController != null && check1.IsActivated() && check2.IsActivated() 
            && check3.IsActivated() && platform1.IsActivated() && platform2.IsActivated())
        {
            characterController.Move(Vector3.up * force * Time.deltaTime);
        }
    }
}
