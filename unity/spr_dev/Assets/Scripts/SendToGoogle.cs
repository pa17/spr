using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SendToGoogle : MonoBehaviour
{
    ResponseHandler responses;

    public GameObject participantIDInput;

    private string participantID;
    private float scenario1, scenario2, scenario3, scenario4, scenario5, scenario6, scenario7;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSdHeBv4TYwZJbrSugEQVgvvMGkVFy1IEn5On565OXhkoTFkXg/formResponse";

    IEnumerator Post(string scenario1, string scenario2, string scenario3, string scenario4, string scenario5, string scenario6, string scenario7)
    {
        WWWForm form = new WWWForm();

        form.AddField("entry.850103797", scenario1);
        form.AddField("entry.419789895", scenario2);
        form.AddField("entry.803556472", scenario3);
        form.AddField("entry.1000874584", scenario4);
        form.AddField("entry.8764226", scenario5);
        form.AddField("entry.1507321686", scenario6);
        form.AddField("entry.496213119", scenario7);

        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;

    }

    public void Start()
    {
        responses = GameObject.Find("Response").GetComponent<ResponseHandler>();
    }


    public void Send()
    {
        scenario1 = responses.scenarioResponses[0];
        scenario2 = responses.scenarioResponses[1];
        scenario3 = responses.scenarioResponses[2];
        scenario4 = responses.scenarioResponses[3];
        scenario5 = responses.scenarioResponses[4];
        scenario6 = responses.scenarioResponses[5];
        scenario7 = responses.scenarioResponses[6];

        Debug.Log("Information sent " + scenario1 + " " + scenario2 + " " + scenario3 + " " + scenario4 + " " + scenario5 + " " + scenario6 + " " + scenario7);

        StartCoroutine(Post(scenario1.ToString(), scenario2.ToString(), scenario3.ToString(), scenario4.ToString(), scenario5.ToString(), scenario6.ToString(), scenario7.ToString()));
    }
}
