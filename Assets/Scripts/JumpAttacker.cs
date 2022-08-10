using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttacker : Attacker
{

    public GameObject reticlePrefab;
    private GameObject reticleInstance;
    private float jumpSpeed = 10;

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
        rb.velocity = Vector2.zero;
        mover.SetCanMove(false);

        reticleInstance = Instantiate(reticlePrefab, transform.position, Quaternion.identity);
        reticleInstance.GetComponent<PlayerMover>().SetCanRotate(false);
    }

    protected override void AttackUp()
    {
        base.AttackUp();
        StartCoroutine(JumpAttack());
    }

    public IEnumerator JumpAttack()
    {
        if (reticleInstance)
        {
            float airTime = Vector3.Distance(reticleInstance.transform.position, transform.position) / jumpSpeed;
            // transform.LookAt(reticleInstance.transform, Vector3.forward);
            transform.up = reticleInstance.transform.position - transform.position;
            rb.velocity = jumpSpeed * Vector3.Normalize(reticleInstance.transform.position - transform.position);
            Destroy(reticleInstance);

            yield return new WaitForSeconds(airTime);
        }

        mover.SetCanMove(true);
        FinishAttack();
    }
}
