using UnityEngine;
using UnityEngine.AI;

public class Roam : MonoBehaviour
{
    NavMeshAgent agent;

    public float newPosRange = 5.0f;
    public int interval = 3;
 
    float time = 0f;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if ((int)time > 0 && (int)time % interval == 0) {
            Vector3 newPos = RandomNavMeshLocation();

            // agent.SetDestination(newPos);
            agent.destination = newPos;
            time = 0f;
        }
    }

    public Vector3 RandomNavMeshLocation() {
        Vector3 randomDirection = Random.insideUnitSphere * newPosRange;

        randomDirection += transform.position;

        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        if (NavMesh.SamplePosition(randomDirection, out hit, newPosRange, 1)) {
            finalPosition = hit.position;
        }

        return finalPosition;
    }
}
