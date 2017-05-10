using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TestSender : MonoBehaviour
{
    public static string host = "http://ec2-34-199-107-106.compute-1.amazonaws.com:3001/lampi";
    public LampiTest.Lampi lamp;
    public string hue;
    public string saturation;
    public string brightness;

    private Dictionary<string, string> headers;

    void Start()
    {
        lamp = new LampiTest.Lampi();
        lamp.color = new LampiTest.Color();
        headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");
        headers.Add("Cookie", "Our session cookie");
    }

    public void lampChangeRequest(float h, float s, float b, bool on)
    {
        StartCoroutine(changeLampState(h, s, b, on));
    }

    public void lampGetRequest()
    {
        StartCoroutine(getLampState());
    }

    IEnumerator changeLampState(float h, float s, float b, bool on)
    {

        lamp.color.h = h;
        lamp.color.s = s;
        lamp.brightness = b;
        lamp.on = on;

        string json = JsonUtility.ToJson(lamp);
        byte[] postData = Encoding.ASCII.GetBytes(json.ToCharArray());
        WWW www = new WWW(host, postData, headers);

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
        }else
        {
            print("Finished Changing Lamp State");
        }
    }

    IEnumerator getLampState()
    {
        WWW www = new WWW(host);
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
        }
        else
        {
            print(www.text);
        }

        var indexh = www.text.IndexOf('h');
        var startindex = indexh + 3;
        var endindex = www.text.IndexOf(',');
        hue = www.text.Substring(startindex, 3);
        print(hue);

    }

    public string getHue()
    {
        return hue;
    }

}
