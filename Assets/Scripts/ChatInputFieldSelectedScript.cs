using UnityEngine;
using System.Collections;

public class ChatInputFieldSelectedScript : MonoBehaviour {
    private bool selected;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (selected && Input.GetKeyDown(KeyCode.Return))
        {
            GetComponentInParent<ChatRoomHandling>().SendComment();
        }
	}

    public void SetSelected(bool selected)
    {
        this.selected = selected;
    }
}
