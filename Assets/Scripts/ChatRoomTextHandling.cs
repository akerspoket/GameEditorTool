using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChatRoomTextHandling : MonoBehaviour {

    public GameObject ChatTextPrefab;
    private List<GameObject> messages = new List<GameObject>();
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PrintText(string text)
    {
        float offsetY = 0;
        for (int i = 0; i < messages.Count; i++)
        {
            offsetY += messages[i].GetComponent<Text>().rectTransform.sizeDelta.y;
        }

        GameObject newChatText = Instantiate(ChatTextPrefab);
        newChatText.transform.SetParent(this.transform);
        //newChatText.transform.localPosition = ChatTextPrefab.transform.localPosition;
        newChatText.transform.localScale = new Vector3(1, 1, 1);
        newChatText.GetComponent<RectTransform>().sizeDelta = ChatTextPrefab.GetComponent<RectTransform>().sizeDelta;
        newChatText.GetComponent<Text>().text = text;

        newChatText.GetComponent<RectTransform>().localPosition = new Vector3(-140, -offsetY + 100, 0); // This is hardcoded cuz it didnt want to be at 0,0,0
        messages.Add(newChatText);
    }
}
