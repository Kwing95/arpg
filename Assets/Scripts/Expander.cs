using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expander : MonoBehaviour
{

    public float growthRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float amount = Time.deltaTime * growthRate;
        transform.localScale = new Vector3(transform.localScale.x + amount, transform.localScale.y + amount, 1);
    }
}
