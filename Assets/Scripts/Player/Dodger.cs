using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodger : MonoBehaviour
{
    private PlayerMover mover;
    private PlayerStatus status;
    private Rigidbody2D rb;
    private float dodgeCooldown = 1;
    private float cooldownCounter = 0;
    private float dodgeDuration = 0.15f;
    private float dodgeSpeed = 15;
    private float staminaCost = 20;
    private bool buttonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<PlayerMover>();
        status = GetComponent<PlayerStatus>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownCounter -= Time.deltaTime;

        bool canDodge = mover.GetCanMove() && mover.GetCanRotate() && status.GetCanAct();

        if (!buttonDown && Input.GetButton("Fire2") && canDodge && cooldownCounter <= 0 && mover.GetIsMoving() &&
            status.UseStamina(staminaCost))
        {
            StartCoroutine(Dodge());
            cooldownCounter = dodgeCooldown;
        }

        buttonDown = Input.GetButton("Fire2");
    }

    public IEnumerator Dodge()
    {
        rb.velocity = dodgeSpeed * mover.GetDirection();
        mover.SetCanMove(false);
        mover.SetCanRotate(false);
        status.SetCanAct(false);

        yield return new WaitForSeconds(dodgeDuration);

        rb.velocity = Vector2.zero;
        mover.SetCanMove(true);
        mover.SetCanRotate(true);
        status.SetCanAct(true);
    }
}
