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
    public GameObject PotionForceUI_Text;

    public GameObject BackpackUI;
    public GameObject BackpackImage;
    public GameObject PotionButton_Backpack;
    public GameObject PotionForceButton_Backpack;

    public bool HasEnteredDungeon;

    public static Scene SceneActive;
    public static string scene;
    public static int PlayerHealth;
    public static int GoldAmount;
    public static int PotionAmount;
    public static int PotionForceAmount;
    public static int NumberOfVisitedRoom;
    public static int KillCounter;


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
        PotionForceAmount = 0;

        HealthUI_Text.GetComponent<Text>().text = PlayerHealth.ToString();
        CoinUI_Text.GetComponent<Text>().text = GoldAmount.ToString();
        PotionUI_Text.GetComponent<Text>().text = PotionAmount.ToString();
        PotionForceUI_Text.GetComponent<Text>().text = PotionForceAmount.ToString();

        BackpackUI.SetActive(false);
        PotionButton_Backpack.SetActive(false);
        BackpackImage.SetActive(false);




        Debug.Log("ok" + this.gameObject);
    }


    void Update()
    {
        HealthUI_Text.GetComponent<Text>().text = PlayerHealth.ToString();
        CoinUI_Text.GetComponent<Text>().text = GoldAmount.ToString();
        PotionUI_Text.GetComponent<Text>().text = PotionAmount.ToString();
        PotionForceUI_Text.GetComponent<Text>().text = PotionForceAmount.ToString();

        if (PotionAmount >= 1)
            PotionButton_Backpack.SetActive(true);
        else
            PotionButton_Backpack.SetActive(false);

        if (PotionForceAmount >= 1)
            PotionForceButton_Backpack.SetActive(true);
        else
            PotionForceButton_Backpack.SetActive(false);

        Debug.Log(PlayerHealth);

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
        Debug.Log("SetHealth Parameter: " + health);
    }

    //----------------------------------//

    public void IncrementGoldAmount()
    {
        GoldAmount += 10;
    }

    public void DecrementGoldAmount(int GoldCost)
    {
        GoldAmount -= GoldCost;
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
    }

    public void DecrementPotionAmount()
    {
        PotionAmount--;
    }

    public int GetPotionAmount()
    {
        return PotionAmount;
    }

    public void IncrementPotionForceAmount()
    {
        PotionForceAmount++;
        PotionForceUI_Text.GetComponent<Text>().text = PotionForceAmount.ToString();
    }

    public void DecrementPotionForceAmount()
    {
        PotionForceAmount--;
    }

    public int GetPotionForceAmount()
    {
        return PotionForceAmount;
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

    //----------------------------------//

    public void OpenBackpack()
    {
        BackpackUI.SetActive(true);
    }

    public void CloseBackPack()
    {
        BackpackUI.SetActive(false);
    }

    public void GiveBackpack()
    {
        BackpackImage.SetActive(true);
    }

    public void UsePotion()
    {
        if(PlayerHealth < 100)
        {
            DecrementPotionAmount();
            HealPlayer();
        }
    }

    public void UsePotionForce()
    {
        DecrementPotionForceAmount();
        //HealPlayer();
    }

    //----------------------------------//

    public void DestroyUI()
    {
        Destroy(CompleteUI);
    }
    public void ActivateUI()
    {
        CompleteUI.SetActive(true);
    }

    public void HideUI()
    {
        CompleteUI.SetActive(false);
    }

    //----------------------------------//

    public int GetKillCounter()
    {
        return KillCounter;
    }

    public void IncrementKillCounter()
    {
        KillCounter++;
    }

    public void BuyPotionRed()
    {
        if(GoldAmount >= 20)
        {
            IncrementPotionAmount();
            DecrementGoldAmount(20);
        }
    }

    public void BuyPotionBlue()
    {
        if (GoldAmount >= 50)
        {
            IncrementPotionForceAmount();
            DecrementGoldAmount(50);
        }
    }


}
