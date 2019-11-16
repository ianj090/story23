using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    static Text scoreText;
    static int score;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score Text").GetComponentInChildren<Text>();
        if (Time.timeSinceLevelLoad < 1)
        {
            score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetScoreText();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Vector3 rowX = new Vector3(Random.Range(-10, 10),
                                    Random.Range(1, 1), Random.Range(7, 7));
            other.transform.position = rowX;
            score += 10;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
