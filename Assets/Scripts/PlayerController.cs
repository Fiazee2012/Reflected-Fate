using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameEventListener hurtListener;
    public GameEventListener healListener;

    

    private Rigidbody2D rb;
    public Vector2 movement;


    
    public int speed = 10;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();


        healListener.enabled = true;
        hurtListener.enabled = true;

    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

    public void Dead()
    {
        speed = 0;
    }
    public void Restart()
    {
        speed = 10;
    }
    
}
