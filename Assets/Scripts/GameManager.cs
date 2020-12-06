using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject WorldPlayer;

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


}
