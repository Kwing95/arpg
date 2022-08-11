using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimitiveHUD : MonoBehaviour
{
    public PlayerStatus status;
    public Text greenHealth;
    public Text redHealth;
    public Text stamina;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stamina.text = Mathf.RoundToInt(status.GetStamina()).ToString();
        greenHealth.text = Mathf.RoundToInt(status.GetGreenHealth()).ToString();
        redHealth.text = Mathf.RoundToInt(status.GetRedHealth()).ToString();
    }
}
