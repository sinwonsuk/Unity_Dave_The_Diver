using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;

    [Range(1, 500)]
    public int startingCount = 250;
    public float AgentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++) 
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {       
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;


        // 기본 위치 지정해서 물고기 Initialize 로 생성함 
        for (int i = 0; i < startingCount; i++)
        {
            Vector2 stratpos = Random.insideUnitCircle * startingCount * AgentDensity;

            transform.position = new Vector3(transform.position.x+stratpos.x, transform.position.y+stratpos.y);

            FlockAgent newAgent = Instantiate(
                agentPrefab,
                transform.position,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
                );
            newAgent.name = gameObject.name;
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (FlockAgent agent in agents)
        {
            // 물고기 일정범위내에 있는 모든 transform을 가져옴 
            List<Transform> context = GetNearbyObjects(agent);

            // boids 알고리즘의 separation,alignment,cohesion 으로 방향을 계산함
            Vector2 move = behavior.CalculateMove(agent, context, this);

            // 속도 증가
            move *= driveFactor;

            // 너무 빠르면 조절 
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            // 이동 
            agent.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();


        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);


        BoxCollider[] boxColliders = contextColliders.OfType<BoxCollider>().ToArray();

        foreach (BoxCollider c in boxColliders)
        {
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }

}
