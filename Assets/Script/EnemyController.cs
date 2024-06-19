using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public Transform spawnPoint;
    public Transform player;
    public float spawnInterval = 2f;
    public int spawnCount = 1;

    public int deerHungerNeed = 200;
    public int dogHungerNeed = 100;
    public int horseHungerNeed = 200;
    public int cowHungerNeed = 300;

    void Start()
    {
        StartCoroutine(SpawnAnimalRoutine());
    }

    IEnumerator SpawnAnimalRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            for (int i = 0; i < spawnCount; i++)
            {
               
                GameObject randomAnimalPrefab = animalPrefabs[Random.Range(0, animalPrefabs.Length)];

                GameObject animal = Instantiate(randomAnimalPrefab, spawnPoint.position, Quaternion.identity);

                EnemyMovement enemyMovement = animal.GetComponent<EnemyMovement>();

                if (enemyMovement != null)
                {
                   enemyMovement.SetTarget(player);
                }
            }
        }
    }
    public void AddHunger(int hungerValue)
    {
        if (gameObject.CompareTag("Deer"))
        {
            Debug.Log("Deer hunger increased by " + hungerValue);
        }
        else if (gameObject.CompareTag("Dog"))
        {
            
            Debug.Log("Dog hunger increased by " + hungerValue);
        }
        else if (gameObject.CompareTag("Horse"))
        {
            
            Debug.Log("Horse hunger increased by " + hungerValue);
        }
        else if (gameObject.CompareTag("Cow"))
        {
            
            Debug.Log("Cow hunger increased by " + hungerValue);
        }
    }
}
