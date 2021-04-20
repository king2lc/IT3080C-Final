using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody2d;
    Vector2 lookDirection = new Vector2(1, 0);
    public float speed = 10.0f;
    float horizontal;
    float vertical;
    public GameObject bulletToRight;
    public GameObject bulletToLeft;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0f;
    Vector2 posistion;
    private AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = clip;
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = transform.position;
        position.x = position.x + 10.0f * horizontal * Time.deltaTime;
        position.y = position.y + 5.0f * vertical * Time.deltaTime;
        transform.position = position;

        if (Input.GetButtonDown ("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire ();
            audioSource.volume = 0.1f;
            audioSource.Play();
        }
    }

    void fire()
    {
        bulletPos = transform.position;
        if (lookDirection.x > 0f)
        {
            bulletPos += new Vector2(+1f, 0f);
            Instantiate (bulletToRight, bulletPos,Quaternion.identity);
        }
        else
        {
            bulletPos += new Vector2(-1f, 0f);
            Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
        }
    }
}
