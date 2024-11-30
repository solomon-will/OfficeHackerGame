using UnityEngine;
using UnityEngine.AI;

public class BossHybridWander : MonoBehaviour
{
    public NavMeshAgent agent;
    public float wanderRadius = 10f;
    public float wanderInterval = 1f;

    private Transform[] targetAreas;
    private float timer;
    private int currentTargetIndex = 0;

    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        TargetAreaManager manager = FindObjectOfType<TargetAreaManager>();
        targetAreas = manager.GetTargetAreas();
    }

    void Update()
    {
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