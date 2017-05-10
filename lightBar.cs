using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lightBar : MonoBehaviour {

    public UnityEngine.UI.Slider hSlider;
    public UnityEngine.UI.Image bar;

    // Use this for initialization
    void Start () {
        bar.color = Color.HSVToRGB(hSlider.value, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        bar.color = Color.HSVToRGB(hSlider.value, 1, 1);
	}
}
