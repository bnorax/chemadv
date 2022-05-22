using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] public List<GameObject> levelList;
   // private List<GameObject> _levelInstances;
    [SerializeField] public GameObject currentLevel;
    private int _currentLevelIndex;

    void ChangeLevel(int levelIndex = 0)
    {
        if(currentLevel) Destroy(currentLevel);
        currentLevel = Instantiate(levelList[levelIndex]);
        _currentLevelIndex = levelIndex;
       // var newLevelInstance = _levelInstances[levelIndex];
        //newLevelInstance.SetActive(true);
       // currentLevel = levelsPrefabs[levelIndex];
        currentLevel.SetActive(true);
    }

    private void Start()
    {
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) ChangeLevel(0);
        if(Input.GetKeyDown(KeyCode.Alpha2)) ChangeLevel(1);
        if(Input.GetKeyDown(KeyCode.R)) ChangeLevel(_currentLevelIndex);
    }

}
