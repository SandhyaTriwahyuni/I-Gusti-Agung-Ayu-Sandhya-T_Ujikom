using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum AnimalType
    {
        Deer,
        Dog,
        Horse,
        Cow
    }

    public AnimalType animalType;
    private float moveSpeed;
    private Transform target;

    void Start()
    {
        switch (animalType)
        {
            case AnimalType.Deer:
                moveSpeed = 250f;
                break;
            case AnimalType.Dog:
                moveSpeed = 300f;
                break;
            case AnimalType.Horse:
                moveSpeed = 300f;
                break;
            case AnimalType.Cow:
                moveSpeed = 150f;
                break;
            default:
                moveSpeed = 0f;
                break;
        }
    }

    void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        if (target != null && Vector3.Distance(transform.position, target.position) < 1f)
        {
            Destroy(gameObject); 
        }
    }


    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
