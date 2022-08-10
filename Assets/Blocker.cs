using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{

    private PlayerMover mover;
    private PlayerStatus status;
    private float blockCooldown = 1;
    private float cooldownCounter = 0;
    private float blockDuration = 0.5f;

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

        if (Input.GetButton("Fire2") && canBlock && cooldownCounter <= 0 && !mover.GetIsMoving())
        {
            StartCoroutine(Block());
            cooldownCounter = blockCooldown;
        }
    }

    public IEnumerator Block()
    {
        mover.SetCanMove(false);
        mover.SetCanRotate(false);
        status.SetCanAct(false);

        yield return new WaitForSeconds(blockDuration);

        mover.SetCanMove(true);
        mover.SetCanRotate(true);
        status.SetCanAct(true);
    }
}
