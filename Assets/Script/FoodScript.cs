using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public float speed = 300f;
    public int hungerValue = 25;
    public float lifetime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward*speed;

        Destroy(gameObject,lifetime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().AddHunger(hungerValue);

            Destroy(gameObject);
        }
    }
}
