using UnityEngine;
using UnityEngine.UI;

public class MashBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateMashBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
