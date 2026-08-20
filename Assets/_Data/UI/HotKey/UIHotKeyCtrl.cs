using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtrl : SaiMonoBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance => instance; 

    protected override void Awake()
    {
        if(UIHotKeyCtrl.instance != null) Debug.LogError("Only 1 UIHotKey");
        UIHotKeyCtrl.instance = this;
    }
}