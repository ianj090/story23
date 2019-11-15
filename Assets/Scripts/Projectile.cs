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
            //Debug.Log("yeah");
            Vector3 rowX = new Vector3(Random.Range(-10, 10),
                                    Random.Range(1, 1), Random.Range(7, 7));
            other.transform.position = rowX;
            score += 10;
            //SetScoreText();

            //StartCoroutine(waiter());
            //string objectColor = other.gameObject.GetComponent<Renderer>().sharedMaterial.name;
            //Debug.Log(objectColor);
            //Debug.Log(main_color);
            //if (main_color.Equals(objectColor))
            //{
            //    count = count + 1;
            //}
            //SetCountText();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        //Debug.Log("Name: " + other.gameObject.name + " Tag: " + other.gameObject.tag);
        //else
        //{
        //    Debug.Log("nah");
        //}
    }

    void SetScoreText()
    {
        //Debug.Log("working");
        scoreText.text = "Score: " + score.ToString();
    }

}
