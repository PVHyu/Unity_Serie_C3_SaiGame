using UnityEngine;

public abstract class ShootableObjectCtrl : SaiMonoBehaviour
{
     [SerializeField] protected Transform model;
    public Transform Model => model; 

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn; 

    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;  

     protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
    }

    protected virtual void LoadDespawn()
    {
        if (this.Despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawn>();
    }

    protected virtual void LoadSO()
    {
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/"+this.GetObjectTypeString()+"/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
    }

    protected abstract string GetObjectTypeString();
}
