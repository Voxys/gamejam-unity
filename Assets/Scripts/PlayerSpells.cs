using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    public int healing = 15;


    public void Normal_Attack()
    {
    
    }


    public void HealingSpell()
    {
        PlayerHealth.instance.HealPlayer(healing);
    }
}
