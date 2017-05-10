using UnityEngine;
using System.Collections;

public class LampState : MonoBehaviour {

    public string color;
    public float brightness;
    public float on;

    public string SaveToString()
    {
       return JsonUtility.ToJson(this);
       //return temp.Replace("\\", "");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
