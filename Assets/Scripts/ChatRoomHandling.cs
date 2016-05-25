using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChatRoomHandling : MonoBehaviour {
    public GameObject ChatRoomPrefab;
    private List<GameObject> rooms = new List<GameObject>();
    private int CurrentRoom = 0;
    private InputField inputField;
    private string standardText;
	// Use this for initialization
	void Start () {
        int numberOfRooms = GetComponentInChildren<Dropdown>().options.Count;
        GameObject newRoom;
        for (int i = 0; i < numberOfRooms; i++)
        {
            newRoom = Instantiate(ChatRoomPrefab);
            newRoom.transform.SetParent(this.transform);
            newRoom.transform.localPosition = ChatRoomPrefab.transform.localPosition;
            newRoom.transform.localScale = new Vector3(1, 1, 1);
            newRoom.GetComponent<RectTransform>().sizeDelta = ChatRoomPrefab.GetComponent<RectTransform>().sizeDelta;
            newRoom.SetActive(false);
            rooms.Add(newRoom);
        }
        SetCurrentChatRoom(0);
        GetComponentInChildren<Dropdown>().onValueChanged.AddListener(SetCurrentChatRoom);
        inputField = GetComponentInChildren<InputField>();
        standardText = inputField.text;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetCurrentChatRoom(int roomNumber)
    {
        rooms[CurrentRoom].SetActive(false);
        rooms[roomNumber].SetActive(true);
        CurrentRoom = roomNumber;
    }

    public void SendComment()
    {
        string text = inputField.text;
        if (text == "")
        {
            return;
        }
        inputField.text = "";

        text = "You: " + text;
        rooms[CurrentRoom].GetComponent<ChatRoomTextHandling>().PrintText(text);
    }

    public void GetComment()
    {

    }
}
