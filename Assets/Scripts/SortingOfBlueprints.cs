using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class SortingOfBlueprints : MonoBehaviour
{
    GameObject onTop;
    List<GameObject> knappar = new List<GameObject>();
    // Use this for initialization
    void Start()
    {

    }

    public void SortList()
    {
        knappar.Sort((IComparer<GameObject>)new sort());
        knappar.Reverse();

        for (int i = 0; i < knappar.Count; i++)
        {
            knappar[i].GetComponent<RectTransform>().localPosition = new Vector3(0, 138 - (25 * i), 0);
        }
    }
    public bool IsFull()
    {
        if (knappar.Count == 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void PlaceOnTop(GameObject p_button)
    {
        if(onTop != null)
        {
            knappar.Add(onTop);
        }
        // FIXA SÅ ATT DET FINNS EN ON TOP I START
        knappar.Remove(p_button);
        onTop = p_button;
        SortList();
        p_button.GetComponent<RectTransform>().localPosition = new Vector3(0, 163, 0);
    }
    public GameObject getOnTop()
    {
        return onTop;
    }
    void Update()
    {
    }
    public void AddToList(GameObject p_button)
    {
        knappar.Add(p_button);
    }
    private class sort : IComparer<GameObject>
    {
        int IComparer<GameObject>.Compare(GameObject _objA, GameObject _objB)
        {
            int t1 = _objA.GetComponent<SphereScript>().GetClicks();
            int t2 = _objB.GetComponent<SphereScript>().GetClicks();
            return t1.CompareTo(t2);
        }
    }
}
