using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.RuleTile.TilingRuleOutput;

//[RequireComponent(typeof(Collider2D))]


enum Flock_Collision
{ 
    None,
    OutSideCollision,
    WallCollision,
    PlayerCollision,

}



public class FlockAgent : MonoBehaviour
{

    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }

    BoxCollider agentCollider;

    public BoxCollider AgentCollider { get { return agentCollider; } }

    Vector3 run_Away = Vector3.zero;

    float speed = 5.0f;

   

    float time = 1.0f;

    Vector3 dir;


    Flock_Collision flock_Collision = Flock_Collision.None;


    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       

        if(collision.gameObject.tag == "Wall")
        {
            flock_Collision = Flock_Collision.None;
        }

        if (collision.gameObject.tag == "Player")
        {        
            Vector3 MoveDir = transform.position - collision.transform.position;
            run_Away = MoveDir.normalized;
            flock_Collision = Flock_Collision.PlayerCollision;
            time = 0;                    
        }

        if (collision.gameObject.tag == "OutCollison")
        {
            Vector3 NearestPoint = Vector3.zero;

            NearestPoint = collision.gameObject.GetComponent<Collider>().ClosestPoint(transform.position);



            dir = NearestPoint- transform.position;


            Vector3 incomingVector = dir;
            incomingVector = incomingVector.normalized;
            Vector3 normalVector = collision.contacts[0].normal;

            Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector);
            reflectVector = reflectVector.normalized;

            run_Away = reflectVector;

           
            time = 0.0f;
            flock_Collision = Flock_Collision.OutSideCollision;
        }

    }

    public void Initialize(Flock flock)
    {
        agentFlock = flock;
        //transform.position = new Vector3 (0, 0, 0);
    }

    public void Move(Vector2 velocity)
    {

        switch (flock_Collision)
        {
            case Flock_Collision.None:
                {
                    time = 0.0f;
                    transform.up = velocity;
                    transform.position += (Vector3)velocity * Time.deltaTime;
                }
                break;
            case Flock_Collision.OutSideCollision:
                {
                    time += Time.deltaTime;


                    transform.position += run_Away * speed * Time.deltaTime;

                    transform.up = run_Away;
                    
                    if (time > 1.0f)
                    {
                        time = 0.0f;
                        flock_Collision = Flock_Collision.None;
                    }
                }
                break;
            case Flock_Collision.WallCollision:
                {

                }
                break;
            case Flock_Collision.PlayerCollision:
                {
                    time += Time.deltaTime;

                    transform.position += run_Away * speed * Time.deltaTime;
                    
                    transform.up = run_Away;

                    if(time > 1.0f)
                    {
                        time = 0.0f;
                        flock_Collision = Flock_Collision.None;                     
                    }
                }
                break;
            default:
                break;
        }









        //if(collisionCheck ==true)
        //{
        //    //transform.position += run_Away * speed * Time.deltaTime;

        //    transform.Translate(run_Away * speed * Time.deltaTime);

        //    transform.up = run_Away;

        //    time += Time.deltaTime;

        //    if(time > 2.5f)
        //    {
        //        time = 0.0f;
        //        collisionCheck = false;
        //    }
        //}
        //else
        //{          
         

        //}
      
        
    }
}
