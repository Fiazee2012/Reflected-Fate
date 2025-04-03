using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    public float lowHealthValue = 1;

    public FloatVariable HP;
    public FloatVariable MaxHP;
    public ChangeHealth changeHealth;
    public GameEvent deadEvent;
    public GameEvent lowHealthEvent;
    public GameObject lowHealthBorders;
    public HeartBeat heartBeat;

    private void Update()
    {
        if(HP.Value == 0f)
        {
            deadEvent.TriggerEvent();
            heartBeat.StopBeat();
        }

        if(HP.Value == lowHealthValue)
        {
            lowHealthEvent.TriggerEvent();
            heartBeat.Beat();
        }
        if(HP.Value > lowHealthValue)
        {
            lowHealthBorders.SetActive(false);
            heartBeat.StopBeat();
        }
    }
    public void Hurt()
    {
        HP.Value = Mathf.Clamp(HP.Value - changeHealth.Damage.Value,0,MaxHP.Value);
    }

    public void Heal()
    {
        HP.Value = Mathf.Clamp(HP.Value + changeHealth.Healing.Value,0, MaxHP.Value);
    }

    public void MaxHeal()
    {
        HP.Value = MaxHP.Value;
    }
}
