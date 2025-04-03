using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public FloatReference HP;
    public FloatReference MaxHP;
    public Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillvalue = HP.Value / MaxHP.Value;
        slider.value = fillvalue;
    }
}

