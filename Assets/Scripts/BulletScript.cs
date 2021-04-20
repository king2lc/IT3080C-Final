using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletScript : MonoBehaviour
{
    public float velX = 50f;
    float velY = 0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMoveScript>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

