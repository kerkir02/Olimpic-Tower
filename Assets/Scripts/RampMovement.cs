using UnityEngine;

public class RampMovement : MonoBehaviour
{
    public float border = 15f;
    public float speed = 20f;

    private Rigidbody2D rb;

    private bool IsToRight; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        IsToRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //move the ramp
        if (IsToRight)
        {
            rb.MovePosition(rb.position + Vector2.right * Time.fixedDeltaTime * speed);
            if (transform.position.x >= border) IsToRight = false;
        }
        else
        {
            rb.MovePosition(rb.position + Vector2.left * Time.fixedDeltaTime * speed);
            if (transform.position.x <= -border) IsToRight = true;
        }
    }
}
