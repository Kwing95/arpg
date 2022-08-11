using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public GameObject parry;

    private PlayerMover mover;
    private PlayerStatus status;
    private float blockCooldown = 1;
    private float cooldownCounter = 0;
    private float blockDuration = 0.5f;
    private float staminaCost = 35;
    private bool buttonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<PlayerMover>();
        status = GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownCounter -= Time.deltaTime;

        bool canBlock = mover.GetCanMove() && mover.GetCanRotate() && status.GetCanAct();

        if (!buttonDown && Input.GetButton("Fire2") && canBlock && cooldownCounter <= 0 && !mover.GetIsMoving() &&
            status.UseStamina(staminaCost))
        {
            StartCoroutine(Block());
            cooldownCounter = blockCooldown;
        }

        buttonDown = Input.GetButton("Fire2");
    }

    public IEnumerator Block()
    {
        mover.SetCanMove(false);
        mover.SetCanRotate(false);
        status.SetCanAct(false);
        Instantiate(parry, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(blockDuration);

        mover.SetCanMove(true);
        mover.SetCanRotate(true);
        status.SetCanAct(true);
    }
}
