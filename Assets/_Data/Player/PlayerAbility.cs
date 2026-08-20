using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : SaiMonoBehaviour
{
    public virtual void Active(AbilitiesCode abilitiesCode)
    {
        Debug.Log("Abilities Code: " + abilitiesCode.ToString());
    }
}