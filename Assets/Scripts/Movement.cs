using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GameObject projectile;
    Vector3 spawnPoint;
    //public Text scoreText;
    //private int score;

    // Start is called before the first frame update
    void Start()
    {
        //scoreText.text = "";
        //score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = this.transform.position;
            position.x -= 0.15f;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            position.x += 0.15f;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.z += 0.15f;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 position = this.transform.position;
            position.z -= 0.15f;
            this.transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnPoint = transform.position + new Vector3(0, 0, 1);
            GameObject bullet = Instantiate(projectile, spawnPoint, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500);

            Destroy(bullet, 1.0f);
        }

        //SetScoreText();

    }

    //void SetScoreText()
    //{
    //    scoreText.text = "Score: " + score.ToString();
    //}
}
