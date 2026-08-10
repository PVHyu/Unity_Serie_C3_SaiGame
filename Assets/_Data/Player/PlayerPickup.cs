using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public void ItemPickup(ItemPickupable itemPickupable)
    {
        if (itemPickupable == null) return;
        ItemCode itemCode = itemPickupable.GetItemCode();
        
        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Picked();
        }
    }
}