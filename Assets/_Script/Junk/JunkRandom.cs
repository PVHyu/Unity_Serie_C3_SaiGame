using UnityEngine;

public class JunkRandom : SaiMonoBehaviour
{
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if(this.junkCtrl != null) return;
        this.junkCtrl = GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.junkCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.junkCtrl.JunkSpawner.Spawn(JunkSpawner.stoneOne,pos, rot);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), 1f);
    }
}