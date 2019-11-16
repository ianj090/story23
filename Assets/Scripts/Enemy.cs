using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;
    Vector3 spawnPoint;
    private float nextFire;
    public GameObject[] Object;
    int actual = 0;
    //float rotSpeed;
    public float speed;
    float Mov = 1;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = nextFire + Random.Range(0.3f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Object[actual].transform.position, transform.position) < Mov)
        {
            actual = Random.Range(0, Object.Length);
            if (actual >= Object.Length)
            {
                actual = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, Object[actual].transform.position, Time.deltaTime * speed);

        if (Time.timeSinceLevelLoad > nextFire)
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
            Vector3 rowX1 = new Vector3(Random.Range(-9, 9),
                                    Random.Range(1, 1), Random.Range(7, 8));
            this.transform.position = rowX1;

            Vector3 rowX2 = new Vector3(Random.Range(-9, 9),
                                    Random.Range(1, 1), Random.Range(-7, -7));
            other.transform.position = rowX2;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
