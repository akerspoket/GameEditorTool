using UnityEngine;
using System.Collections;

public class SetTargetedSource : MonoBehaviour
{
    GameObject m_objectToAlter;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    public void SetGameObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);// kan va fel gameobjectposition


        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("new raycast");
            float minDist = 100000;
            Vector3 rayhitpos = hit.collider.transform.position;
            GameObject[] ground = GameObject.FindGameObjectsWithTag("Finish");
            
            foreach (GameObject item in ground)
            {
                Debug.Log("evaling item");
                float currDist = (rayhitpos - item.transform.position).magnitude;
                Debug.Log(currDist);
                if (currDist < minDist)
                {
                    Debug.Log(item);
                    m_objectToAlter = item;
                    minDist = currDist;
                    Debug.Log("minDist " + minDist);
                }
            }
            //m_objectToAlter = closestObject;

            //if (hit.transform != gameObject.transform)
            //{
            //    if (hit.collider.gameObject.tag != "Respawn")
            //    {
            //        m_objectToAlter = hit.collider.gameObject;
            //    }
            //}
        }
    }
    public GameObject GetGameObject()
    {
        return m_objectToAlter;
    }
}
