using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : InteracterbleObject
{
    protected virtual void OnMouseEnter()
    {
        Interact();
    }
}
