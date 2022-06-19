using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class FormManager : MonoBehaviour
{
    [SerializeField] Survey survey;
    [SerializeField] GameObject submitButton;
    [SerializeField] string feedBack1;

    //Add the string data from google form here
    readonly string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdNhteu0llY6JgweukbS5pyoAEyZh68yvCr4tB_nw46UTcUFA/formResponse";
    readonly string entry = "entry.257516790";

    public void Send()
    {
        feedBack1 = survey.myResults;
        StartCoroutine(Post(feedBack1));
    }

    private IEnumerator Post(string string_1)
    {
        WWWForm form = new WWWForm();
        form.AddField(entry, string_1);
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
    }    
}