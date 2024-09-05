using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Steered Cohesion")]
public class SteeredCohesionBehavior : FilteredFlockBehavior
{

    Vector2 currentVelocity;
    public float agentSmoothTime = 0.5f;
    // 즉 여긴 군집하도록 한거구나 
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector2.zero;

        //add all points together and average
        Vector2 cohesionMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);

        // 모든 포지션을 더한후(가운데로 더하는중)  
        foreach (Transform item in filteredContext)
        {
            cohesionMove += (Vector2)item.position;
        }

        // 범위내에 수에따라 나눔 
        cohesionMove /= context.Count;

        //create offset from agent position 이건 왜한걸까 아 여기서 멀어지게 하는건가 본데 
        cohesionMove -= (Vector2)agent.transform.position;


        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);
        return cohesionMove;
    }
}
