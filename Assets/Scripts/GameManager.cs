using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject CompleteUI;

    public GameObject WorldPlayer;
    public GameObject HealthUI_Text;
    public GameObject CoinUI_Text;
    public GameObject PotionUI_Text;
    
    public GameObject BackpackUI;
    public GameObject PotionButton_Backpack;

    public bool HasEnteredDungeon;

    public static Scene SceneActive;
    public static string scene;
    public static int PlayerHealth;
    public static int GoldAmount;
    public static int PotionAmount;
    public static int NumberOfVisitedRoom;



    //----------------------------------//
    // TODO : BuyPotions
    //
    // SI GoldAmount >=10
    // 
    //  -> BuyPotions
    //  ---> DecrementGoldAmount
    //  ---> IncrementPotionAmount
    //
    // TODO : UsePotions
    // 
    // SI PotionAmount >= 1
    //  
    //  -> UsePotions
    //  ---> DecrementPotionAmount
    //  ---> IncrementPlayerHealth
    //
    //
    //----------------------------------//

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(CompleteUI);
    }

    void Start()
    {
        PlayerHealth = 100;
        GoldAmount = 50;
        PotionAmount = 0;
        
        HealthUI_Text.GetComponent<Text>().text = PlayerHealth.ToString();
        CoinUI_Text.GetComponent<Text>().text = GoldAmount.ToString();
        PotionUI_Text.GetComponent<Text>().text = PotionAmount.ToString();

        BackpackUI.SetActive(false);
        PotionButton_Backpack.SetActive(false);

        


        Debug.Log("ok" + this.gameObject);
    }


    void Update()
    {
        HealthUI_Text.GetComponent<Text>().text = PlayerHealth.ToString();
        CoinUI_Text.GetComponent<Text>().text = GoldAmount.ToString();
        PotionUI_Text.GetComponent<Text>().text = PotionAmount.ToString();

        if (PotionAmount >= 1)
            PotionButton_Backpack.SetActive(true);
        else
            PotionButton_Backpack.SetActive(false);

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

    public void SetPlayerHealth(int health)
    {
        PlayerHealth = health;
    }

    //----------------------------------//

    public void IncrementGoldAmount()
    {
        GoldAmount+=10;
    }

    public void DecrementGoldAmount()
    {
        GoldAmount-= 10;
        CoinUI_Text.GetComponent<Text>().text = GoldAmount.ToString();
        Debug.Log(GoldAmount);
    }

    public int GetGoldAmount()
    {
        return GoldAmount;
    }

    //----------------------------------//

    public void IncrementPotionAmount()
    {
        PotionAmount++;
        PotionUI_Text.GetComponent<Text>().text = PotionAmount.ToString();
        Debug.Log(PotionAmount);
    }

    public void DecrementPotionAmount()
    {
        PotionAmount--;
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

    public void OpenBackpack()
    {
        BackpackUI.SetActive(true);
    }

    public void CloseBackPack()
    {
        BackpackUI.SetActive(false);
    }

    public void UsePotion()
    {
        DecrementPotionAmount();
        HealPlayer();
    }

    public void DestroyUI()
    {
        Destroy(CompleteUI);
    }
}
