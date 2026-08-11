using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : InventoryAbstract
{
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
        this.LoadRigidbody();
        this.LoadInventory();
    }   

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.3f;
        Debug.LogWarning(transform.name + " LoadTrigger", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        this._rigidbody.isKinematic = true;
        Debug.LogWarning(transform.name + " LoadRigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);

        if(collider.name != "ItemPickupable") return;
        ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();

        ItemCode itemCode = itemPickupable.GetItemCode();
        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory; 

        if (this.inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}