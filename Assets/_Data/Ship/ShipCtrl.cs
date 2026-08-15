using UnityEngine;

public class ShipCtrl : AbilityObjectCtrl
{
    [Header("Ship")]
    protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override string GetObjectTypeString()
    {
        return ObjectType.Ship.ToString();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.Find("Inventory").GetComponent<Inventory>();
        // Debug.LogWarning(transform.name + " LoadInventory", gameObject);
    }
}