using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Pressable : SaiMonoBehaviour
{
    public virtual void Pressed()
    {
        Debug.Log("Pressed: " + transform.parent.parent.name);
    }
}