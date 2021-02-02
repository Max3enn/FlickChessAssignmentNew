using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    [SerializeField] string _nextLevelName;
    Enemy[] _enemies;
    void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {
        if (EnemiesAreAllDead())
        GoToNextLevel();
    }

        void GoToNextLevel()
    {
        Debug.Log("Go to level" + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }

    private bool EnemiesAreAllDead()
    {
        foreach (var enemy in _enemies);
        
            if (Enemy.gameObject.activeSelf)
            return false;
        }
        return true;
    }
