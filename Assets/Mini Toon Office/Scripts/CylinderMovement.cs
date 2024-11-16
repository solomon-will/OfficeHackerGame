using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    public float speed = 2f; 
    public float rotationSpeed = 150f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Move towards the current waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        float distance = direction.magnitude;

        // If the cylinder is close to the waypoint, switch to the next one
        if (distance < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            // Move and rotate towards the waypoint
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;

            // Rotate the cylinder to face the direction of movement
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
