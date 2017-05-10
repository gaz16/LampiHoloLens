using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class saturationSlider : MonoBehaviour, IPointerUpHandler {

    public Material yourGradientMaterial;
    public UnityEngine.UI.Slider hueSlider;
    public UnityEngine.UI.Slider brightnessSlider;
    public UnityEngine.UI.Slider satSlider;
    TestSender sender;


	// Use this for initialization
	void Start () {
        yourGradientMaterial.SetColor("_Color", Color.red);
        yourGradientMaterial.SetColor("_Color2", Color.white);
        sender = gameObject.AddComponent<TestSender>();
        //satSlider.onValueChanged.AddListener(ListenerMethod);
	}
	
	// Update is called once per frame
	void Update () {
        yourGradientMaterial.SetColor("_Color", Color.HSVToRGB(hueSlider.value, 1, 1));
        yourGradientMaterial.SetColor("_Color2", Color.white);
	}

    void ListenerMethod(float value)
    {
        float h = hueSlider.value;
        float s = satSlider.value;
        float b = brightnessSlider.value;
        bool on = true;


        sender.lampChangeRequest(h, s, b, on);
    }

    public void OnPointerUp(PointerEventData data)
    {
        Debug.Log("Saturation slider has been deselected");
        float h = hueSlider.value;
        float s = satSlider.value;
        float b = brightnessSlider.value;
        bool on = true;
        sender.lampChangeRequest(h, s, b, on);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}

