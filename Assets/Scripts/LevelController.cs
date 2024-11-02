using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private Enemy[] enemies;

    private void OnEnable()
    {
        enemies = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null)
                return;
        }

        Debug.Log("You killed all enemies");
    }
}
