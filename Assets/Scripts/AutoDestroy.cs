using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float timeToLive = 10;
    private float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        counter = timeToLive;
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0)
            Destroy(gameObject);
    }
}
