using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private movement player;
    private float moveSpeed;
    private Vector3 directionToPlayer;
    private Vector3 localScale;
    private int wait = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType(typeof(movement)) as movement;
        moveSpeed = Random.Range(5f,15f);
        localScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
    }

    private void LateUpdate()
    {
        if (rb.velocity.x > 0)
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        else if (rb.velocity.x < 0)
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
    }
}
