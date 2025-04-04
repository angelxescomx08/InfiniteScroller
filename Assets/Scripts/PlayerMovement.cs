using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float upForce;
    Rigidbody2D rb;
    private float yInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        yInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.up * yInput * upForce);
    }
}
