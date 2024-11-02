using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private float launchPower = 100f;

    private Vector3 initialPosition;
    private bool birdWasLaunch;

    private float timeSittingAround;

    private LineRenderer lineRenderer;


    private void Awake()
    {
        initialPosition = transform.position;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        if (birdWasLaunch && GetComponent<Rigidbody2D>().linearVelocity.magnitude < 0.1f)
        {
            timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 10 ||
            transform.position.y < -10 ||
            transform.position.x > 10  ||
            transform.position.x < -10 || timeSittingAround > 3f)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        
        lineRenderer.enabled = true;
    }


    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        
        Vector2 direction = initialPosition - transform.position;

        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.AddForce(direction * launchPower);
        rigidbody2D.gravityScale = 1;

        birdWasLaunch = true;
        lineRenderer.enabled = false;

    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = transform.position.z;

        transform.position = newPosition;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, initialPosition);
    }
}
