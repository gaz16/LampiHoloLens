using UnityEngine;
using System.Collections;

public class color : MonoBehaviour {

    public float h;
    public float s;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
