using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SendToGoogle : MonoBehaviour
{
    ResponseHandler responses;

    public GameObject participantIDInput;

    private string participantID;
    private float scenario1;
    private float scenario2;
    private float scenario3;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSdHeBv4TYwZJbrSugEQVgvvMGkVFy1IEn5On565OXhkoTFkXg/formResponse";

    IEnumerator Post(string scenario1, string scenario2, string scenario3)
    {
        WWWForm form = new WWWForm();

        form.AddField("entry.850103797", scenario1);
        form.AddField("entry.419789895", scenario1);
        form.AddField("entry.803556472", scenario1);
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

        Debug.Log("Information sent " + scenario1 + " " + scenario2 + " " + scenario3);

        StartCoroutine(Post(scenario1.ToString(), scenario2.ToString(), scenario3.ToString()));
    }
}
