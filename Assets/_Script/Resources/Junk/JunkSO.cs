using UnityEngine;

[CreateAssetMenu(fileName = "Junk", menuName = "ScriptableObject/Junk")]

public class JunkSO : ScriptableObject
{
    [Header("Junk")]
    public string junkName = "Junk";
    public int hpMax = 2;
}