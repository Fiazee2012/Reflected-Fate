using UnityEngine;
using System.Collections;

public class DamageZone : MonoBehaviour
{
    public GameEvent hurtEvent;
    public bool continuousDamage;
    public float damageFrequency = 2;
    private Coroutine damageCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hurtEvent.TriggerEvent();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(continuousDamage && damageCoroutine == null)
        {
            damageCoroutine = StartCoroutine(ApplyContinuousDamage());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
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
