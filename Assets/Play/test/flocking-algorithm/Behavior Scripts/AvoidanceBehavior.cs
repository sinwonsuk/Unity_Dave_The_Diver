using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FilteredFlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector2.zero;

        //add all points together and average
        Vector2 avoidanceMove = Vector2.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            Vector3 NearestPoint = Vector3.zero;

                NearestPoint = item.gameObject.GetComponent<BoxCollider>().ClosestPoint(agent.transform.position);

           

       //     Vector3 NearestPoint2 = item.gameObject.GetComponent<MeshCollider>().ClosestPoint(agent.transform.position);


            // Mask mask = agent.GetComponent<Mask>();




                                                                                // 애를 키우면 더 빠르게 벗어나겠네 원이 커지는 개념
            if (Vector2.SqrMagnitude(NearestPoint - agent.transform.position) < flock.SquareAvoidanceRadius)
            {
                nAvoid++;
                avoidanceMove += (Vector2)(agent.transform.position - item.position);
            }
        }
        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        return avoidanceMove;
    }
}
