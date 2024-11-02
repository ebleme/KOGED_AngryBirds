using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject cloudPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();

        if (bird != null)
        {
            Instantiate(cloudPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();

        if (enemy != null)
        {
            return;
        }

        if (collision.GetContact(0).normal.y < -0.5f)
        {
            Instantiate(cloudPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
