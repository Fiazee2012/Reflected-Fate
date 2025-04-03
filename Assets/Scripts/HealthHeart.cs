using UnityEngine;

public class HealthHeart : MonoBehaviour
{
    public Sprite full, half, empty;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Full()
    {
        spriteRenderer.sprite = full;

    }
    public void Half()
    {
        spriteRenderer.sprite = half;

    }
    public void Empty()
    {
        spriteRenderer.sprite = empty;

    }  
    
}
