using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttacker : Attacker
{

    public GameObject bullet;
    private float shotCost = 10;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private float attackRate = 0.5f;
    private float cooldownCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        cooldownCounter -= Time.deltaTime;
    }

    protected override void AttackHold()
    {
        mover.SetCanRotate(false);
        if(cooldownCounter <= 0 && status.UseStamina(shotCost))
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * mover.GetDirection();
            cooldownCounter = attackRate;
        }
    }

    protected override void AttackUp()
    {
        base.AttackUp();
        mover.SetCanRotate(true);
        FinishAttack();
    }
}
