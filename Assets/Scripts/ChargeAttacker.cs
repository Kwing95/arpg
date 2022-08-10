using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttacker : Attacker
{

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
        mover.SetCanMove(false);

        rb.velocity = chargeSpeed * mover.GetDirection();
    }

    protected override void AttackUp()
    {
        base.AttackUp();
        mover.SetCanMove(true);
        FinishAttack();
    }
}
