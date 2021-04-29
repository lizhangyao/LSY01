using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float fInput = 0.0f;
    private float maxSpeed = 5;
    private bool bFaceRight = true;
    private bool bGrounded = false;
    private float moveforce = 50f;
    public float jumpForce = 300;
    Transform mgroundcheck;
    public Rigidbody2D heroBody;

    // Start is called before the first frame update
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
        mgroundcheck = transform.Find("groundcheck");
    }

    // Update is called once per frame
    void Update()
    {
        fInput = Input.GetAxis("Horizontal");
        if (fInput < 0 && bFaceRight)
            flip();
        else if (fInput > 0 && !bFaceRight)
            flip();
        bGrounded = Physics2D.Linecast(transform.position, mgroundcheck.position, 1 << LayerMask.NameToLayer("ground"));
    }

    private void FixedUpdate()
    {
        float fInput = Input.GetAxis("Horizontal");
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        //控制移动
        if (fInput * rigidBody.velocity.x < maxSpeed)
        {
            rigidBody.AddForce(Vector2.right * fInput * moveforce);
        }
        //限制最大速度
        if (Mathf.Abs(rigidBody.velocity.x) > maxSpeed)
        {
            rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);
        }
        if (fInput > 0 && !bFaceRight)
        {
            flip();
        }
        else if (fInput < 0 && bFaceRight)
        {
            flip();
        }
        bool bjump = false;
 //       bjump = Input.GetButton("bjump");
        if(bGrounded)
        {
            bjump = Input.GetKeyDown(KeyCode.Space);
            Vector2 upForce = new Vector2(0, 1);
            if (bjump)
            {
                heroBody.AddForce(upForce * jumpForce);
            }
        }
    }
    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }
}
