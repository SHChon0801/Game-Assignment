using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Questing 
{
    public bool isActive;

    public string title;
    public string description;
    public int experienceReward;

    public QuestGoal goal;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + " : Success");
    }
}
