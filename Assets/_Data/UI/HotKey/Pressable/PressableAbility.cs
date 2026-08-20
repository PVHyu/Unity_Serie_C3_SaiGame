using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PressableAbility : Pressable
{
    [SerializeField] protected AbilitiesCode ability;

    public override void Pressed()
    {
        Debug.Log("PressableAbility: " + ability.ToString());
        PlayerCtrl.Instance.PlayerAbility.Active(ability);
    }
}