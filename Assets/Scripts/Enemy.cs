using UnityEngine;
using System.Collections;
using System;


public class Enemy : MonoBehaviour
{
    public GameEvent hurtEvent;
    public bool continuousDamage;
    public float damageFrequency = 2;

    public float speed = 5;
    public float distanceRange = 5;
    private Coroutine damageCoroutine;
    private bool playerInRange;
    private bool playerCollided;
    private float tempSpeed;

    private Rigidbody2D rb;
    private Vector2 currentPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPosition = rb.position;
        tempSpeed = speed;
    }
    public void FixedUpdate()
    {
        if(!playerInRange)
        {
            Move();
        }
        else
        {
            
        }
    }       
        private void Move()
    {       
        if ((rb.position.x - currentPosition.x) > distanceRange)
        {
            speed = -speed;
        }
        else
        {
            if ((rb.position.x - currentPosition.x) < -distanceRange)
            {
                speed = -speed;
            }
        }

        rb.linearVelocity = new Vector2(speed,0);
    }

    void Pursue(Rigidbody2D playerRigidbody)
    {
        float difPos = playerRigidbody.position.x - rb.position.x;
        if (difPos != 0)
        { 
            rb.linearVelocity = new Vector2(Math.Sign(difPos) * Math.Abs(tempSpeed), 0); 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hurtEvent.TriggerEvent();

            if (continuousDamage && damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(ApplyContinuousDamage());
            }

            tempSpeed = 0;
        }
        else
        {
            speed = -speed;
            float relPos = rb.position.x - collision.transform.position.x;
            currentPosition.x = rb.position.x + distanceRange * Math.Sign(relPos);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tempSpeed = speed;
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Pursue(collision.attachedRigidbody);
        }

        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            currentPosition = rb.position;
        }
    }

    private IEnumerator ApplyContinuousDamage()
    {
        while (continuousDamage)
        {
            yield return new WaitForSeconds(damageFrequency);
            hurtEvent.TriggerEvent();
        }
    }

}
