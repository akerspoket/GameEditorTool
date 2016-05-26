using UnityEngine;
using System.Collections;

public class EraseScript : MonoBehaviour
{
    SetTargetedSource hejhej;
    GameObject m_objectToAlter;
    // Use this for initialization
    void Start()
    {
        //camera = GetComponent<Camera>();

    }

    // Update is called once per frame
    public void Erase()
    {
        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(gameObject.transform.position);// kan va fel gameobjectposition
        //if (Physics.Raycast(ray, out hit))
        //{
        //    if (hit.transform != gameObject.transform)
        //    {
        //        if (hit.collider.gameObject.tag != "Respawn")
        //        {
        //            Destroy(hit.collider.gameObject);
        //        }
        //    }
        //}
        hejhej = GameObject.FindObjectOfType(typeof(SetTargetedSource)) as SetTargetedSource;
        m_objectToAlter = hejhej.GetGameObject();
        Destroy(m_objectToAlter);
    }
}
