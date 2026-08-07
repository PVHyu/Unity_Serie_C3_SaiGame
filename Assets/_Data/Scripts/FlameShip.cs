using UnityEngine;

public class FlameShip : SaiMonoBehaviour
{
    [SerializeField] protected Transform flame;
    public Transform Flame => flame;
    [SerializeField] protected float flameMax = 2;
    [SerializeField] protected float flameMin = 1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.flame != null) return;
        this.flame = transform;
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void Update()
    {
        this.UpdateFlame();
    }

    protected virtual void UpdateFlame()
    {
        if (this.flame == null) return;
        float flameScale = Random.Range(this.flameMin, this.flameMax);
        this.flame.localScale = new Vector3(flame.localScale.x, flameScale, flame.localScale.z);
    }
}
