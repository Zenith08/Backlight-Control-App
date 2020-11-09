using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkCaller : MonoBehaviour
{
    private string root = "http://10.0.0.89:8080/backlight?mode=";

    public void SendRequest(string mode)
    {
        Debug.Log("Received request to set colour to " + mode);
        StartCoroutine(GetRequest(root + mode));
    }

    IEnumerator GetRequest(string uri)
    {
        Debug.Log("Get request for " + uri);
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }
}
