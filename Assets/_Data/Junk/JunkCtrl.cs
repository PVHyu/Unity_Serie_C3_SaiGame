using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model; 

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn => junkDespawn; 

    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;  

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadJunkSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;
        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
    }

    protected virtual void LoadJunkSO()
    {
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/Junk/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
    }
}