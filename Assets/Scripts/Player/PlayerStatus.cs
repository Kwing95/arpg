using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    private bool canAct = true;

    private int maxGreenHealth = 100;
    private int maxRedHealth = 100;
    private int maxStamina = 100;

    private float greenHealth = 100;
    private float redHealth = 100;
    private float stamina = 100;

    private float staminaRecovery = 15;
    private float greenRecovery = 1;

    private float damageBonus = 1;
    private float defenseBonus = 1;
    private float speedBonus = 1;

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        stamina = Mathf.Min(maxStamina, stamina + (Time.deltaTime * staminaRecovery));
    }

    private void ResetHealth()
    {
        greenHealth = maxGreenHealth;
        redHealth = maxRedHealth;
        stamina = maxStamina;
    }

    public bool UseStamina(float amount)
    {
        if(stamina >= amount)
        {
            stamina -= amount;
            return true;
        }
        return false;
    }

    public void SetCanAct(bool value)
    {
        canAct = value;
    }
    public bool GetCanAct()
    {
        return canAct;
    }

    public float GetGreenHealth()
    {
        return greenHealth;
    }
    public float GetRedHealth()
    {
        return redHealth;
    }
    public float GetStamina()
    {
        return stamina;
    }

}
