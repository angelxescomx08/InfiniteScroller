using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private float spriteWidth;
    // Start is called before the first frame update
    void Start()
    {
        spriteWidth = GetComponent<SpriteRenderer>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -spriteWidth)
        {
            transform.Translate(Vector2.right * spriteWidth * 2);
        }
    }
}
