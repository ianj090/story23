using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile_e : MonoBehaviour
{
    static Text scoreText;
    static int score;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score Text").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        SetScoreText();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }

    void SetScoreText()
    {
        //Debug.Log("working");
        scoreText.text = "Score: " + score.ToString();
    }

}
