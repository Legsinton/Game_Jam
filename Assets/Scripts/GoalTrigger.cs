using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTriggerScript : MonoBehaviour
{
    private bool hasReachedGoal = false;
    public float velocityThreshold = 0.1f; // Set a small threshold for detecting "stopped"

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

        if (other.CompareTag("Player"))
        {
            // Check if the ball's velocity is below the threshold
            if (rb.velocity.magnitude < velocityThreshold && !hasReachedGoal)
            {
                hasReachedGoal = true; // Mark that the goal has been reached
                Debug.Log("Goal Reached! Ball has stopped.");
                //HandleGoalReached(); 
            }
        }
    }
}
