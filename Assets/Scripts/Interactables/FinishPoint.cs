using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : Interactable
{
    protected override void Interact()
    {
        SceneController.instance.NextLevel();
    }
}
