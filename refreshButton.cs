using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class refreshButton : MonoBehaviour, IPointerClickHandler {

    TestSender sender;
    public UnityEngine.UI.Slider hueS;
    public UnityEngine.UI.Slider satS;
    public UnityEngine.UI.Slider briS;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Refresh clicked!");
        sender.lampGetRequest();
        Debug.Log(sender.getHue());
        hueS.value = float.Parse(sender.getHue());
    }

    // Use this for initialization
    void Start () {
        sender = gameObject.AddComponent<TestSender>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
