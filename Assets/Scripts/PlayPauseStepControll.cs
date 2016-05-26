using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayPauseStepControll : MonoBehaviour {
    private List<GameObject> enemies = new List<GameObject>();
	// Use this for initialization
	void Start () {
	
	}
	
    public void AddEnemy(GameObject newEnemy)
    {
        enemies.Add(newEnemy);
    }
    public void RemoveEnemy(GameObject enemy)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == enemy)
            {
                enemies.RemoveAt(i);
                break;
            }
        }
    }
    public void PlayAll()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<AIStepping>().SetPlay();
        }
    }
    public void PauseAll()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<AIStepping>().SetPause();
        }
    }
    public void StepAll()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<AIStepping>().TakeStep();
        }
    }
    public void StepBackAll()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<AIStepping>().StepBack();
        }
    }

}
