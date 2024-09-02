using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Line_Move : MonoBehaviour
{
    float speed = 30f;
    bool attack_Check = false;
    float time = 0.0f;
    public float head_Speed = 30.0f;
    public float head_Speed_02 = 25.0f;

    Rigidbody rb;   

    [SerializeField]
    Harpoon_Head_Move head_Move;

    bool Set_Attack_Check(bool _Check)
    {
        return attack_Check = _Check;
    }
    bool Get_Attack_Check()
    {
        return attack_Check;
    }


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <4 && attack_Check ==false)
        { 


            transform.localScale += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);

            head_Move.transform.Translate(new Vector3(head_Speed  * Time.deltaTime, 0.0f, 0.0f));
        }
         
        if(transform.localScale.x > 4 && attack_Check == false)
        {
            time += Time.deltaTime;
        }

        if(time > 1.0f && attack_Check == false)
        {
            attack_Check = true;
          
        }

        if(attack_Check == true && transform.localScale.x > 0)
        {
            speed += 0.1f;

            transform.localScale -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);

            head_Move.transform.Translate(new Vector3(-head_Speed_02 * Time.deltaTime, 0.0f, 0.0f));
        }

        if(attack_Check == true && transform.localScale.x < 0)
        {
            speed = 30.0f;
              attack_Check = false;
            time = 0.0f;
          
        }

    }
}
