using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTriggerScript : MonoBehaviour
{
    public static bool hasReachedGoal = false;
    public float velocityThreshold = 0.1f; // Set a small threshold for detecting "stopped"
    public GameObject victoryPanel;
    

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
                VictoryPanel(); 
            }
        }
    }
    private void VictoryPanel()
    {
        Vector3 cameraCenter = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));
        RectTransform panelRectTransform = victoryPanel.GetComponent<RectTransform>();
        panelRectTransform.position = new Vector3(cameraCenter.x, cameraCenter.y, panelRectTransform.position.z);
        victoryPanel.SetActive(true);
    }
}
