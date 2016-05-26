using UnityEngine;
using System.Collections;

public class EditScript : MonoBehaviour
{
    SetTargetedSource hejhej;
    GameObject m_objectToAlter;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void IncreaseSource()
    {
        hejhej = GameObject.FindObjectOfType(typeof(SetTargetedSource)) as SetTargetedSource;
        m_objectToAlter = hejhej.GetGameObject();
        Destroy(m_objectToAlter);
        Debug.Log(m_objectToAlter);
    }

    public void DecreaseSource()
    {
        hejhej = GameObject.FindObjectOfType(typeof(SetTargetedSource)) as SetTargetedSource;
        m_objectToAlter = hejhej.GetGameObject();
        Destroy(m_objectToAlter);
        Debug.Log("Hej2");

    }
}
