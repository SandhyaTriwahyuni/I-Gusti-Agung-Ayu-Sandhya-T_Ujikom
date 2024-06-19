using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float scale = 3f;
    public CharacterController characterController;
    public Animator animator;
    private bool isGameOver = false;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    void Start()
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float actualSpeed = baseSpeed * Mathf.Abs(moveHorizontal);

        Vector3 movement = new Vector3(moveHorizontal, 0, 0);

        if (animator != null && !isGameOver)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

            if (moveHorizontal > 0)
            {
                animator.SetBool("MovingRight", true);
                animator.SetBool("MovingLeft", false);
            }
            else if (moveHorizontal < 0)
            {
                animator.SetBool("MovingRight", false);
                animator.SetBool("MovingLeft", true);
            }
            else
            {
                animator.SetBool("MovingRight", false);
                animator.SetBool("MovingLeft", false);
            }
        }

        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && !isGameOver)
        {
            ThrowFood();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            OpenPauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            TriggerGameOver();
        }

        if (!isGameOver)
        {
            characterController.Move(movement * actualSpeed * Time.deltaTime);
        }
    }

    void ThrowFood()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = bulletSpawnPoint.TransformDirection(Vector3.forward) * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("Bullet prefab is missing Rigidbody component!");
        }
    }




    void OpenPauseMenu()
    {
        Debug.Log("Opening pause menu!");
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        animator.SetTrigger("GameOverTrigger");
        Debug.Log("Game Over!");
    }
}
