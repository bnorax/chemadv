using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] public List<GameObject> levelList;
   // private List<GameObject> _levelInstances;
    [SerializeField] public GameObject currentLevel;
    [SerializeField] public int currentLevelIndex;

    public void ChangeLevel(int levelIndex = 0)
    {
        if(currentLevel) Destroy(currentLevel);
        currentLevel = Instantiate(levelList[levelIndex]);
        currentLevelIndex = levelIndex;
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
        if(Input.GetKeyDown(KeyCode.R)) ChangeLevel(currentLevelIndex);
    }

}
