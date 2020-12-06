using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject WorldPlayer;
    public static Scene SceneActive;
    public static string scene;

    public static int NumberOfVisitedRoom;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void IncrementNumberOfVisitedRoom()
    {
        NumberOfVisitedRoom++;
    }

    public int GetNumberOfVisitedRoom()
    {
        return NumberOfVisitedRoom;
    }

    public void SetActiveScene(Scene a_scene)
    {
        scene = a_scene.name;
    }

    public string GetSceneActive()
    {
        return scene;
    }


}
