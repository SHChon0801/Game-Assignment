using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private levelWindow levelwindow;

    private void Awake()
    {
        levelSystem levelSystem = new levelSystem();
        Debug.Log(levelSystem.getLevelNumber());
        levelSystem.addExperience(50);
        Debug.Log(levelSystem.getLevelNumber());
        levelSystem.addExperience(60);
        Debug.Log(levelSystem.getLevelNumber());

        levelwindow.setLevelSystem(levelSystem);
    }
}
