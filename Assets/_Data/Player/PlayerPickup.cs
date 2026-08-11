using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public void ItemPickup(ItemPickupable itemPickupable)
    {
        if (itemPickupable == null) return;
        ItemCode itemCode = itemPickupable.GetItemCode();

        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory; 
        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}