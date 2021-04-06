using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodoUnido : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public bool movimiento = true;
    public float velocidad = 1.2f;
    public float fuerzaDeSalto = 3.5f;
    public bool wallSliding;
    public bool istouchingFront;
    public float wallSlidingSpeed = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Check.enSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaDeSalto);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Check.enSuelo && Check.enMuralla == true)
        {

            rb.velocity = new Vector2(rb.velocity.x, fuerzaDeSalto);

            if (movimiento)
            {
                movimiento = false;
            }
            else
            {
                movimiento = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (movimiento)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);

        }
        else
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
        }

        if (istouchingFront == true && Check.enSuelo == false)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }
        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && !Check.enSuelo)
        {
            istouchingFront = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        istouchingFront = false;

    }
}
