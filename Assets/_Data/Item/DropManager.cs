using System.Collections.Generic;
using UnityEngine;

public class DropManager : SaiMonoBehaviour
{
    private static DropManager instance;
    public static DropManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        DropManager.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList)
    {
        if (dropList == null || dropList.Count == 0)
        {
            Debug.LogWarning("Drop list is empty or null.");
            return;
        }

        if (dropList[0] == null || dropList[0].itemSO == null)
        {
            Debug.LogWarning("Drop entry is missing item data.");
            return;
        }

        Debug.Log(dropList[0].itemSO.itemName);
    }
   
}