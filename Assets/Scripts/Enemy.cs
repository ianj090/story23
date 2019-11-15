using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;
    Vector3 spawnPoint;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.transform.position;
        position.z -= 0.025f;
        this.transform.position = position;

        if (Time.time > nextFire)
        {
            nextFire = nextFire + Random.Range(0.3f, 2.0f);
            spawnPoint = transform.position + new Vector3(0, 0, -1);
            GameObject bullet = Instantiate(projectile, spawnPoint, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * -450);

            Destroy(bullet, 1.0f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            Debug.Log("yeah");
            Vector3 rowX = new Vector3(Random.Range(-10, 10),
                                    Random.Range(1, 1), Random.Range(3, 3));
            this.transform.position = rowX;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("yeah");
            Destroy(other.gameObject);
        }
    }
}
