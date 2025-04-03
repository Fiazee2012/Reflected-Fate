using Unity.VisualScripting;
using UnityEngine;

public class ChangeHealth : MonoBehaviour
{
    public GameEvent hurtEvent;
    public GameEvent healEvent;
    public FloatVariable Damage;
    public FloatVariable Healing;


    private void OnMouseDown()
    {
        hurtEvent.TriggerEvent();
        healEvent.TriggerEvent();
    }


}
