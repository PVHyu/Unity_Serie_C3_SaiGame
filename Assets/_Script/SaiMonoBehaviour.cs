using UnityEngine;

public class SaiMonoBehaviour : MonoBehaviour
{
    protected void Start()
    {
        //For override
    }
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    } 

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        //For override
    }

    protected virtual void ResetValue()
    {
        //For override
    }
}
