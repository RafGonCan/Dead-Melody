using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// TheGuitarAbility is a MonoBehaviour that handles the player's guitar ability.
/// It detects obstacles within a specified radius and toggles their lift state when the ability is activated.
/// </summary>

public class TheGuitarAbility : MonoBehaviour
{
    [SerializeField] private Transform abilityCheckTransform;
    [SerializeField, Range(0f, 100.0f)] private float abilityRadius = 0f;
    [SerializeField] private ParticleSystem soundWaveArea;

    // Dictionary to store obstacles and their lifted state
    private Dictionary<Animator, bool> obstaclesInRange = new Dictionary<Animator, bool>();

    // Update is called once per frame
    void Update()
    {
        Collider2D[] abilityHit = Physics2D.OverlapCircleAll(abilityCheckTransform.position, abilityRadius);
        HashSet<Animator> currentObstacles = new HashSet<Animator>();

        // Check for obstacles in range
        foreach (var hit in abilityHit)
        {
            Obstacle obstacle = hit.GetComponent<Obstacle>();
            Animator animator = hit.GetComponent<Animator>();

            // check if the gameObject has the Obstacle and Animator
            if (obstacle && animator)
            {
                currentObstacles.Add(animator);

                // Check if the obstacle is already in the dictionary, if not, add it and his state
                if (!obstaclesInRange.ContainsKey(animator))
                {
                    bool isLifted = animator.GetBool("UpMovement");
                    obstaclesInRange.Add(animator, isLifted);
                    Debug.Log("Obstacle in range!!!");
                }
            }
        }

        // Check for obstacles that are no longer in range and remove them from the dictionary
        List<Animator> ObstaclesToRemove = new List<Animator>();

        // Check if the obstacle is not in the current obstacles
        foreach (var obstacle in new List<Animator>(obstaclesInRange.Keys))
        {
            if (!currentObstacles.Contains(obstacle))
            {
                ObstaclesToRemove.Add(obstacle);
            }
        }

        // Remove the obstacles that are no longer in range
        foreach (var obstacle in ObstaclesToRemove)
        {
            obstaclesInRange.Remove(obstacle);
        }

        // Check if the player pressed the ability button
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Guitar play");
            soundWaveArea.Play();

            // Check if there are obstacles in range to activate the ability
            foreach (var obstacle in new List<Animator>(obstaclesInRange.Keys))
            {
                if (obstacle != null)
                {
                    bool isLifted = obstaclesInRange[obstacle];
                    Debug.Log("Ability hit!!!");

                    if (isLifted)
                    {
                        obstacle.SetBool("UpMovement", false);
                        obstacle.SetBool("DownMovement", true);
                    }
                    else
                    {
                        obstacle.SetBool("UpMovement", true);
                        obstacle.SetBool("DownMovement", false);
                    }

                    // Toggle the state for this obstacle
                    obstaclesInRange[obstacle] = !isLifted;
                }
            }
        }
    }

    // Draw the ability range in the editor
    private void OnDrawGizmos()
    {
        if (abilityCheckTransform != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(abilityCheckTransform.position, abilityRadius);
        }
    }
}
