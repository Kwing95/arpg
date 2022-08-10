using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    [SerializeField] private float speed = 5;

    private Rigidbody2D rb;
    private bool canMove = true;
    protected bool canRotate = true;
    private float horizontal = 0;
    private float vertical = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (canMove)
        {
            rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0);

            if (rb.velocity != Vector2.zero && canRotate)
            {
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90;
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    public void SetCanRotate(bool value)
    {
        canRotate = value;
    }

    public bool GetCanMove()
    {
        return canMove;
    }
    public bool GetCanRotate()
    {
        return canRotate;
    }

    public bool GetIsMoving()
    {
        return rb.velocity != Vector2.zero;
    }
    public Vector2 GetDirection()
    {
        return new Vector2(Mathf.Cos(Mathf.Deg2Rad * (rb.rotation + 90)), Mathf.Sin(Mathf.Deg2Rad * (rb.rotation + 90)));
    }
}
