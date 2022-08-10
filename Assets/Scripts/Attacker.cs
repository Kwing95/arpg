using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : MonoBehaviour
{

    protected PlayerMover mover;
    private PlayerStatus status;
    private bool attackDown = false;
    protected Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        mover = GetComponent<PlayerMover>();
        rb = GetComponent<Rigidbody2D>();
        status = GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    protected void Update()
    {

        if(!attackDown && Input.GetButton("Fire1") && status.GetCanAct())
            AttackDown();
        else if(attackDown && Input.GetButton("Fire1"))
            AttackHold();
        else if(attackDown && !Input.GetButton("Fire1"))
            AttackUp();

        attackDown = Input.GetButton("Fire1");
    }

    protected virtual void AttackDown()
    {
        status.SetCanAct(false);
        attackDown = true;
    }

    protected virtual void AttackHold()
    {

    }

    protected virtual void AttackUp()
    {
        attackDown = false;
    }

    protected void FinishAttack()
    {
        status.SetCanAct(true);
    }

}
