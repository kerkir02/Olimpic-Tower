using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 30f;
    public float horizontalInput;
    public float border = 30f;
    public float gravityScale = 5f;

    private Rigidbody2D rb;

    private bool IsInMove;
    private bool IsGameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        IsInMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //move the player
        horizontalInput = Input.GetAxis("Horizontal");
        if (IsInMove)
        {
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }

        //block move out of screen
        if (transform.position.x > border)
        {
            transform.position = new Vector3(border, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -border)
        {
            transform.position = new Vector3(-border, transform.position.y, transform.position.z);
        }

        //unleash player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale = gravityScale;
            IsInMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
