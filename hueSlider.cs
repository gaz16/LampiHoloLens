﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class hueSlider : MonoBehaviour, IPointerUpHandler {

    public UnityEngine.UI.Slider hSlider;
    public UnityEngine.UI.Slider brightnessSlider;
    public UnityEngine.UI.Slider satSlider;
    TestSender sender;

    // Use this for initialization
    void Start () {
        sender = gameObject.AddComponent<TestSender>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Hue slider has been deselected");
        float h = hSlider.value;
        float s = satSlider.value;
        float b = brightnessSlider.value;
        bool on = true;
        sender.lampChangeRequest(h, s, b, on);
    }
}
