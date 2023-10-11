using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // message to show them ray shoots on Interactable
    public string promptMessage;

    // this will be called from our player
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {

    }
}
