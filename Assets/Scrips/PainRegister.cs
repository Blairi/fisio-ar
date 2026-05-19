using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PainRegister : MonoBehaviour
{

    public Slider painSlider;
    public TextMeshProUGUI painValueText;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePainValue(painSlider.value);
    }

    public void UpdatePainValue(float value)
    {
        int painValue = (int)value;
        painValueText.text = painValue.ToString();
    }

    public void SavePainValue()
    {
        int painValue = (int)painSlider.value;
        Debug.Log("Valor de dolor guardado: " + painValue);
    }
}
