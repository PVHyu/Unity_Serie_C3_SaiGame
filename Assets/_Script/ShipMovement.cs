using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 worldPosition;
    [SerializeField] protected float speed = 0.1f;

    void FixedUpdate()
    {
        if (Camera.main == null || Mouse.current == null)
            return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        this.worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.worldPosition.z = 0;
        Vector3 newPos = Vector3.Lerp(transform.position, worldPosition, this.speed);
        transform.position = newPos;
    }
}
