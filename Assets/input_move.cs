using UnityEngine;
using UnityEngine.InputSystem;
public class input_move : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Vector2 moveInput;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * speed;
    }
    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
