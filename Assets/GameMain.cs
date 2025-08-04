using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameMain : MonoBehaviour
{
    public TextThrower textThrower;
    
    [SerializeField] private int currentLevel;
    [SerializeField] private List<LevelData> levels;

    
    //----------------
    [System.Serializable]
    public class LevelData
    {
        public List<GameObject> levelObjects;
    }

    private void Awake()
    {
        G.Main = this;
        G.Camera = FindAnyObjectByType<Camera>();
        G.Camera.gameObject.AddComponent<CameraShake>();
    }

    void Start()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if(i == currentLevel)
                LoadLevel(currentLevel);
            else
            {
                foreach (var obj in levels[i].levelObjects.ToList())
                {
                    obj.SetActive(false);
                }
            }
        }
        
    }

    public void NextLevel()
    {
        if (currentLevel + 1 == levels.Count)
        {
            _ = G.SceneLoader.Load("End");
        }
        else
        {
            LoadLevel(currentLevel + 1);
        }
        
    }

    public void LoadLevel(int num)
    {
        foreach (var obj in levels[currentLevel].levelObjects.ToList())
        {
            obj.SetActive(false);
        }

        currentLevel = num;
        
        foreach (var obj in levels[currentLevel].levelObjects.ToList())
        {
            obj.SetActive(true);
        }
    }
}
