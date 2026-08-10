using UnityEngine;

public abstract class PlayerAbstract : SaiMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.root.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + " LoadPlayerCtrl", gameObject);
    }
}