using UnityEngine;

public class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        this.CreateImpactFX();
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
        this.DestroyObject();
    }

    protected virtual void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }


    public virtual void SetDamage(int damage)
    {
        this.damage = damage;
    }

    protected virtual void CreateImpactFX()
    {
        string fxName = this.GetImpactFX();

        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);

        if (fxImpact == null) return;
        fxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFX()
    {
        return FXSpawner.impact;
    }
}