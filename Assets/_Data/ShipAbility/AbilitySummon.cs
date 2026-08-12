using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class AbilitySumon : BaseAbility
{
    [Header("Ability Sumon")] 
    [SerializeField] protected Spawner spawner;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }

    protected virtual void Summoning()
    {
        if(!this.isRead) return;
        this.Summon(); 
    }

    protected virtual void Summon()
    {
        Transform minionPrefab = this.spawner.RandomPrefab();
        Transform minion = this.spawner.Spawn(minionPrefab, transform.position, transform.rotation);
        minion.gameObject.SetActive(true);
        this.Active();
    }
}