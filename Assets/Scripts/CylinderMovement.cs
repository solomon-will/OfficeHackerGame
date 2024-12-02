using UnityEngine;
using UnityEngine.AI;

public class CylinderMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float wanderRadius = 10f;
    public float wanderInterval = 1f;
    public GameObject exclamationPoint;

    private Transform[] targetAreas;
    private float timer;
    private int currentTargetIndex = 0;

    private bool isChasingRadio = false; // Tracks if the boss is chasing the radio
    private GameObject radioObject; // Tracks the radio object

    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        TargetAreaManager manager = FindObjectOfType<TargetAreaManager>();
        targetAreas = manager.GetTargetAreas();
        exclamationPoint.SetActive(false);

        // Subscribe to the radio event
        RadioClick.OnRadioActivated += MoveToRadio;
    }

    void Update()
    {
        
        if (isChasingRadio)
        {
            
            // Check if boss has reached the radio
            if (!agent.pathPending && agent.remainingDistance <= (agent.stoppingDistance + 0.02))
            {
                TurnOffRadio();
                exclamationPoint.SetActive(false);
                isChasingRadio = false; // Resume wandering behavior
            }
            return;
        }

        // Regular wandering behavior
        timer += Time.deltaTime;

        if (timer >= wanderInterval)
        {
            if (Random.value < 0.01f && targetAreas.Length > 0)
            {
                MoveToNextTarget();
            }
            else
            {
                WanderRandomly();
            }
            timer = 0;
        }
    }



    void OnDestroy()
    {
        // Unsubscribe to avoid memory leaks
        RadioClick.OnRadioActivated -= MoveToRadio;
    }

    void WanderRandomly()
    {
        Vector3 newPos = RandomNavMeshPoint(transform.position, wanderRadius);
        agent.SetDestination(newPos);
    }

    void MoveToNextTarget()
    {
        Vector3 targetPosition = targetAreas[currentTargetIndex].position;
        agent.SetDestination(targetPosition);

        currentTargetIndex = (currentTargetIndex + 1) % targetAreas.Length;
    }

    void MoveToRadio(Vector3 radioPosition)
    {
        // Make sure the radioObject is found when needed
        radioObject = FindObjectOfType<RadioClick>()?.gameObject;

        if (radioObject != null)
        {
            // Set chasing state and move toward the radio
            isChasingRadio = true;
            agent.SetDestination(radioPosition);
            exclamationPoint.SetActive(true);
            Debug.Log("Boss is moving to the radio at " + radioPosition);
        }
        else
        {
            Debug.LogError("Radio object is not assigned!");
        }
    }

    void TurnOffRadio()
    {
        if (radioObject != null)
        {
            RadioClick radioScript = radioObject.GetComponent<RadioClick>();
            if (radioScript != null)
            {
                radioScript.TurnOff();
                Debug.Log("Boss turned off the radio.");
            }
        }
    }

    Vector3 RandomNavMeshPoint(Vector3 origin, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += origin;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, 1))
        {
            return hit.position;
        }
        return origin;
    }
}
