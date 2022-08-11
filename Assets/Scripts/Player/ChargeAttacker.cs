using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttacker : Attacker
{
    public GameObject glow;

    [SerializeField] private float chargeCost = 45;
    [SerializeField] private float chargeSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    protected override void AttackDown()
    {
        base.AttackDown();
        mover.SetCanMove(false);
    }

    protected override void AttackHold()
    {
        status.enabled = false;
        mover.SetCanMove(false);

        bool enoughStamina = status.UseStamina(chargeCost * Time.deltaTime);

        glow.SetActive(enoughStamina);
        rb.velocity = (enoughStamina ? chargeSpeed : mover.GetSpeed()) * mover.GetDirection();
    }

    protected override void AttackUp()
    {
        status.enabled = true;
        base.AttackUp();

        glow.SetActive(false);
        mover.SetCanMove(true);
        FinishAttack();
    }
}
