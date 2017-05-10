using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class powerLight : MonoBehaviour, IPointerClickHandler
{

    public Material yourMaterial;
    public UnityEngine.UI.Button power;
    public UnityEngine.UI.Slider hueSlider;
    public UnityEngine.UI.Slider brightnessSlider;
    public UnityEngine.UI.Slider satSlider;
    public bool lampIsOn;
    TestSender sender;


    // Use this for initialization
    void Start()
    {
        power.image.color = Color.red;
        sender = gameObject.AddComponent<TestSender>();
        lampIsOn = true;
        //satSlider.onValueChanged.AddListener(ListenerMethod);
    }

    // Update is called once per frame
    void Update()
    {
        if (lampIsOn) { 
        power.image.color = Color.HSVToRGB(hueSlider.value, 1, 1);
        }

    }

    void ListenerMethod(float value)
    {
        float h = hueSlider.value;
        float s = satSlider.value;
        float b = brightnessSlider.value;
        bool on = true;


        sender.lampChangeRequest(h, s, b, on);
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (lampIsOn)
        {
            lampIsOn= false;
            power.image.color = Color.gray;
        }
        else
        {
            lampIsOn = true;
        }
        Debug.Log("power button has been clicked");
        float h = hueSlider.value;
        float s = satSlider.value;
        float b = brightnessSlider.value;
        bool on = lampIsOn;
        sender.lampChangeRequest(h, s, b, on);
    }

}
