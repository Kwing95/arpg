using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttacker : Attacker
{

    public GameObject explosion;
    public GameObject reticlePrefab;
    private GameObject reticleInstance;
    private float minJumpDistance = 2;
    private float jumpCost = 45;
    private float jumpSpeed = 10;
    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        if(!jumping)
            base.Update();
    }

    protected override void AttackDown()
    {
        base.AttackDown();
        rb.velocity = Vector2.zero;
        mover.SetCanMove(false);

        reticleInstance = Instantiate(reticlePrefab, transform.position, Quaternion.identity);
        reticleInstance.GetComponent<PlayerMover>().SetCanRotate(false);
    }

    protected override void AttackHold()
    {        
        base.AttackHold();

        if(ValidJump() && !status.UseStamina(jumpCost * Time.deltaTime))
                AttackUp();
    }

    protected override void AttackUp()
    {
        base.AttackUp();

        if(ValidJump())
            StartCoroutine(JumpAttack());
        else
        {
            if(reticleInstance)
                Destroy(reticleInstance);

            mover.SetCanMove(true);
            FinishAttack();
        }

    }

    private bool ValidJump()
    {
        return reticleInstance && Vector2.Distance(reticleInstance.transform.position, transform.position) > minJumpDistance;
    }

    public IEnumerator JumpAttack()
    {
        if (reticleInstance)
        {
            jumping = true;
            float airTime = Vector3.Distance(reticleInstance.transform.position, transform.position) / jumpSpeed;
            transform.up = reticleInstance.transform.position - transform.position; // Face reticle
            rb.velocity = jumpSpeed * Vector3.Normalize(reticleInstance.transform.position - transform.position); // Jump
            Destroy(reticleInstance);

            yield return new WaitForSeconds(airTime);
        }

        jumping = false;
        Instantiate(explosion, transform.position, Quaternion.identity);
        mover.SetCanMove(true);
        FinishAttack();
    }
}
