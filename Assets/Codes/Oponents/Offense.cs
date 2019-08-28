using UnityEngine;
using UnityEngine.AI;

public class Offense : Oponent
{
    public float repositionTargetRate = 4;

    #region Methods
    public override void StartNavAgent()
    {
        InvokeRepeating("SetDestinationAndGo", 0, Random.Range(2, repositionTargetRate));
    }

    void SetDestinationAndGo()
    {
        GetComponent<NavMeshAgent>().SetDestination(GameMng.instance.p1.transform.position);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            GameMng.instance.Score -= 50;
        }
    }
    #endregion
}
