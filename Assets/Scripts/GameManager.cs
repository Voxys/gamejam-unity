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
    public static int PlayerHealth;
    public static int GoldAmount;
    public static int PotionAmount;
    public static int NumberOfVisitedRoom;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PlayerHealth = 100;
        GoldAmount = 100;
    }

    
    void Update()
    {
        
    }

    //----------------------------------//


    public int GetPlayerHealth()
    {
        return PlayerHealth;
    }

    public void HealPlayer()
    {
        PlayerHealth += 20;
    }

    public void TakeDamage(int damage)
    {
        PlayerHealth -= damage;
    }

    //----------------------------------//

    public void IncrementGoldAmount()
    {
        GoldAmount+=10;
    }

    public void DecrementGoldAmount()
    {
        GoldAmount-= 10;
    }

    public int GetGoldAmount()
    {
        return GoldAmount;
    }

    //----------------------------------//

    public void IncrementPotionAmount()
    {
        GoldAmount++;
    }

    public void DecrementPotionAmount()
    {
        GoldAmount--;
    }

    public int GetPotionAmount()
    {
        return PotionAmount;
    }

    //----------------------------------//

    public void IncrementNumberOfVisitedRoom()
    {
        NumberOfVisitedRoom++;
    }

    public int GetNumberOfVisitedRoom()
    {
        return NumberOfVisitedRoom;
    }

    //----------------------------------//

    public void SetActiveScene(Scene a_scene)
    {
        scene = a_scene.name;
    }

    public string GetSceneActive()
    {
        return scene;
    }


}
