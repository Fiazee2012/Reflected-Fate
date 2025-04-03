using UnityEngine;
using UnityEngine.UI;

public class HealthHearts : MonoBehaviour
{
    public FloatReference HP;
    public FloatReference RafaMaxHP;
    public HealthHeart heart1, heart2, heart3;
        
    void Update()
    {
        switch (HP.Value)
        {
            case 6f:
                heart1.Full();
                heart2.Full();
                heart3.Full();
                break;

            case 5f:
                heart1.Full();
                heart2.Full();
                heart3.Half();
                break;

            case 4f:
                heart1.Full();
                heart2.Full();
                heart3.Empty();
                break;

            case 3f:
                heart1.Full();
                heart2.Half();
                heart3.Empty();
                break;

            case 2f:
                heart1.Full();
                heart2.Empty();
                heart3.Empty();
                break;

            case 1f:
                heart1.Half();
                heart2.Empty();
                heart3.Empty();
                break;

            case 0f:
                heart1.Empty();
                heart2.Empty();
                heart3.Empty();
                break;
        }
       
    }    
}

