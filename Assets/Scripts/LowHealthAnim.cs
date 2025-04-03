using UnityEngine;

public class LowHealthAnim : MonoBehaviour
{
    public SpriteRenderer[] heartSprites; // Assign the 4 sprites in the Inspector
    public float beatSpeed = 2f;
    public float minAlpha = 0.5f;
    public float maxAlpha = 1f;
    public GameObject lowHealthBorders;

    private void Start()
    {
        lowHealthBorders.SetActive(false);
        foreach (var sprite in heartSprites)
        {
            Color color = sprite.color;
            color.a = 0; 
            
        }
    }
    public void LowHealth()
    {
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.PingPong(Time.time * beatSpeed, 1));

        foreach (var sprite in heartSprites)
        {
            Color color = sprite.color;
            color.a = alpha; // Update transparency
            sprite.color = color;
        }
    }
}
