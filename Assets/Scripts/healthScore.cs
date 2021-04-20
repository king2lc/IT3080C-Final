using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class healthScore : MonoBehaviour
{
    public Text HPText;
    public Text ScoreText;
    public int score;
    public int healthAdd;
    bool alive = true;
    public static int finalScore;

    int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Score());
    }

    // Update is called once per frame
    void Update()
    {
        HPText.text = "Player Health: " + health.ToString();
        ScoreText.text = "Player Score: " + score.ToString();

        if (healthAdd > 15)
        {
            healthAdd = healthAdd - 15;
            health = health + 1;
        }
    }
    void OnCollisionEnter2D (Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                health = health - 1;
            }
            
            if (health == 0)
            {
                Destroy(gameObject);
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
                finalScore = score;
            }
               
        }
        IEnumerator Score()
    {
        while(alive)
        {
            yield return new WaitForSeconds(1);
            score = score + 1;
            healthAdd = healthAdd + 1;
        }
    }
}
