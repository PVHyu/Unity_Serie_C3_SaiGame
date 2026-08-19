using System.Collections.Generic;
using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
    //[Header("Item Drop")]
     protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 8);
    }

    protected virtual void Test()
    {
        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        this.DropItemIndex(0, dropPos, transform.rotation);
    }

    protected virtual void DropItemIndex(int itemIndex, Vector3 dropPos, Quaternion dropTop)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];

        
        ItemDropSpawner.Instance.DropFromInventory(itemInventory, dropPos, transform.rotation);
        if(itemInventory.itemCount == 0) this.inventory.Items.Remove(itemInventory);
    }
}