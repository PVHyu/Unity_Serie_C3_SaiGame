using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public abstract class ShipShooting : SaiMonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;

    void Update()
    {
        this.IsShooting();
    }

    void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if(!this.isShooting) return;

        this.shootTimer += Time.smoothDeltaTime;
        if(this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);

        if(newBullet == null) return;

        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShotter(transform.parent);
        Debug.Log("Shooting");
    }

    protected abstract bool IsShooting();
}
