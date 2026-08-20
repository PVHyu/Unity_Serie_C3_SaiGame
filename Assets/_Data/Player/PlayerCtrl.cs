using UnityEngine;

public class PlayerCtrl : SaiMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [SerializeField] private ShipCtrl currentShip;
    public ShipCtrl CurrentShip => currentShip;

    [SerializeField] private PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;
    [SerializeField] private PlayerAbility playerAbility;
    public PlayerAbility PlayerAbility => playerAbility;

    protected override void Awake()
    {
        base.Awake();
        if(PlayerCtrl.instance != null) Debug.LogError("There is more than one PlayerCtrl in the scene");
        PlayerCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickup();
        this.LoadPlayerAbility();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = transform.Find("PlayerPickup").GetComponent<PlayerPickup>();
        Debug.LogWarning(transform.name + " LoadPlayerPickup", gameObject);
    }

    protected virtual void LoadPlayerAbility()
    {
        if (this.playerAbility != null) return;
        this.playerAbility = transform.GetComponentInChildren<PlayerAbility>();
        Debug.LogWarning(transform.name + " LoadPlayerPickup", gameObject);
    }
}