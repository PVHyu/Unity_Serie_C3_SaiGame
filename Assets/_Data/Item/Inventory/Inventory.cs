using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Inventory : SaiMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.IronOre, 10);
    }

    public virtual bool AddItem(ItemCode itemCode, int addcount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount + addcount;

        if(newCount > itemInventory.maxStack) return false;

        itemInventory.itemCount = newCount;
        return true;
    }

    public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find(item => item.itemProfile.itemCode == itemCode);
        if(itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        return itemInventory;
    }    

    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach(ItemProfileSO profile in profiles)
        {
            if(profile.itemCode == itemCode)
            {
                ItemInventory itemInventory = new ItemInventory();
                itemInventory.itemProfile = profile;
                itemInventory.maxStack = profile.defaultMaxStack;
                this.items.Add(itemInventory);
                return itemInventory;
            }
        }
        return null;
    }
}