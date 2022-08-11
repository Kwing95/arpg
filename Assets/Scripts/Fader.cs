using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public float fadeRate = 2;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float amount = fadeRate * Time.deltaTime;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - amount);

        if(sr.color.a <= 0)
            Destroy(gameObject);
    }
}
