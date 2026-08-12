using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ShipShootByMouse : ShipShooting
{
     protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
