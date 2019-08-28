using UnityEngine;
using UnityEngine.AI;

public class Defense : Oponent
{
    public BlockerType currentType;

    public override void StartNavAgent()
    {
        InvokeRepeating("SetDestinationAndGo", 0, .01f);
    }

    void SetDestinationAndGo()
    {
        switch (currentType) {
            case BlockerType.Random:
                Vector3 randomDirection = Random.insideUnitSphere * 50;
                randomDirection += transform.position;
                NavMeshHit hit;
                Vector3 finalPosition = Vector3.zero;
                if (NavMesh.SamplePosition(randomDirection, out hit, 50, 1))
                {
                    finalPosition = hit.position;
                }
                GetComponent<NavMeshAgent>().SetDestination(finalPosition);
                break;

            case BlockerType.BallBlocker:
                GetComponent<NavMeshAgent>().SetDestination(GameMng.instance.ball.transform.position);
                break;

        }
    }

    public enum BlockerType { Random, BallBlocker}

}
