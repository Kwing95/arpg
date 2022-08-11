using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{

    public GameObject bullet;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Explosion()
    {
        GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = 10 * Vector2.right;
    }

    public IEnumerator Attack()
    {
        Shoot();
        yield return new WaitForSeconds(3);
        Explosion();
        yield return new WaitForSeconds(3);
        StartCoroutine(Attack());
    }
}
