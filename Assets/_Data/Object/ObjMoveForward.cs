using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ObjMoveForward : ObjMovement
{
    [SerializeField] protected Transform moveTarget;

    protected override void FixedUpdate()
    {
        GetMousePosition();
        base.FixedUpdate();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    protected virtual void LoadTarget()
    {
        if(this.moveTarget != null) return;
        this.moveTarget = transform.GetChild(0);
    }

    protected virtual void GetMousePosition()
    {
        this.targetPosition = moveTarget.position;
        this.targetPosition.z = 0;
    }

}
