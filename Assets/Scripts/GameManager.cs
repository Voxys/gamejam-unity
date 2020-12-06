using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject WorldPlayer;
    public static Scene SceneActive;

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
        SceneActive = a_scene;
    }

    public Scene GetSceneActive()
    {
        return SceneActive;
    }


}
