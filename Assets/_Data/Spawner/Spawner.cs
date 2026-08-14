using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;
using UnityEngine;

public abstract class Spawner : SaiMonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if(this.holder != null) return;
        this.holder = transform.Find("Holder");
//        Debug.LogWarning(transform.name + ": LoadHodler", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if(this.prefabs == null) this.prefabs = new();
        if(this.prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }

        this.HidePrefabs();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach(Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    } 

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        
        Transform prefab = this.GetPrefabByName(prefabName);

        if(prefab == null)
        {
            Debug.LogWarning("Prefab not found:  " + prefabName);
            return null;
        }

        return this.Spawn(prefab, spawnPos, rotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        newPrefab.SetParent(this.holder);
        this.spawnedCount++;

        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj == null) continue;

            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        if (this.poolObjs.Contains(obj)) return;

        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            Debug.Log(prefab.ToString());
            if (prefab.name == prefabName) return prefab;
        }

        return null;
    }

    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }

    public virtual void Hold(Transform obj)
    {
        if (obj == null) Debug.LogError("Obj is NULL");
        if (this.holder == null) Debug.LogError("Holder is NULL");

        obj.SetParent(this.holder);
    }
}
