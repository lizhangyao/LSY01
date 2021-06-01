using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D enemyBody;
    private Transform frontcheck;
    // Start is called before the first frame update
   
    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        frontcheck = transform.Find("frontcheck");
    }
    private void FixedUpdate()
    {
        enemyBody.velocity = new Vector2(transform.localScale.x * moveSpeed, enemyBody.velocity.y);

        Collider2D[] colliders = Physics2D.OverlapPointAll(frontcheck.position);

        foreach(Collider2D c in colliders)
        {
            if(c.tag == "wall")
            {
                flip();
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
}
