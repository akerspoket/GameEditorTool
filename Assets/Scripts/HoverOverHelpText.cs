using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HoverOverHelpText : MonoBehaviour {
    public string helpText = "";
    public GameObject ObjectToInstantiate;
    private GameObject textBox;
    private float helpTextPopUpTime = 1; // in seconds
    private float timer;
    private bool inside = false;
    private bool alreadyPrinted = false;
    private float textWidth;
    // Use this for initialization
    void Start() {
        int fontSize = ObjectToInstantiate.GetComponentInChildren<Text>().fontSize;
        textWidth = fontSize * helpText.Length;
        Debug.Log(textWidth);
    }

    // Update is called once per frame
    void Update() {
        if (inside && !alreadyPrinted)
        {
            timer += Time.deltaTime;
            if (timer > helpTextPopUpTime)
            {
                Vector3 position = Input.mousePosition;
                position.x += 55f;
                position.y -= 35f;
                textBox = (GameObject)Instantiate(ObjectToInstantiate);
                textBox.transform.SetParent(GetComponentInParent<Canvas>().transform);
                textBox.transform.position = position;
                textBox.GetComponentInChildren<Text>().text = helpText;
                Canvas.ForceUpdateCanvases(); // Potentaily very harmful TODOXX
                textWidth = textBox.GetComponentInChildren<Text>().rectTransform.sizeDelta.x;
                textBox.GetComponentInChildren<Image>().rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, textWidth);
                alreadyPrinted = true;
            }
        }
    }

    public void MouseEntered()
    {
        inside = true;
    }

    public void MouseExit()
    {
        inside = false;
        timer = 0;
        alreadyPrinted = false;
        Destroy(textBox);
    }
}
