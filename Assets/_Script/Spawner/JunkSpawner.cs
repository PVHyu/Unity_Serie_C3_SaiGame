using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;
    public static JunkSpawner Instance => instance;

    public static string stoneOne = "Stone_1";

    protected override void Awake()
    {
        base.Awake();
        if(JunkSpawner.instance != null) Debug.LogError("Only 1 JunkSpawner allow to exist");
        JunkSpawner.instance = this;
    }
}
