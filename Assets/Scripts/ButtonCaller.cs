using UnityEngine;
using UnityEngine.UI;

public class ButtonCaller : MonoBehaviour
{
    public string target;

    private void Start()
    {
        target = GetComponentInChildren<Text>().text.ToLower();
        Debug.Log("Button loaded target as " + target);
    }

    public void ButtonPressed()
    {
        Debug.Log("CreatingRequest to set colour to " + target);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<NetworkCaller>().SendRequest(target);
    }
}
