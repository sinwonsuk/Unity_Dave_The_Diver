using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_ready_State_Helper
{
    // Start is called before the first frame update

    List<GameObject> gameObjects;

    Dictionary<string, GameObject> dave_Attack_Help_Object;



    public List<GameObject> GetgameObjects()
    {
        return gameObjects;
    }

    public Dictionary<string, GameObject> Get_dave_Attack_Help_Object()
    {
        return dave_Attack_Help_Object;
    }


    void Start()
    {
        
    }

    public Attack_ready_State_Helper(Dictionary<string, GameObject> _dave_Attack_Help_Object)
    {
        dave_Attack_Help_Object = _dave_Attack_Help_Object;
    }


    public void ChildSetActive_Off()
    {
        foreach (var gameObjects in dave_Attack_Help_Object)
        {
            if(gameObjects.Key == "Rope")
            {
                gameObjects.Value.GetComponent<LineRenderer> ().enabled = false;
                continue;
            }

            gameObjects.Value.SetActive(false);
        }      
    }


    public void Attack_Ready(bool _check)
    {
        if(_check == true)
        {
            foreach (var gameObject in dave_Attack_Help_Object)
            {
                if(gameObject.Key == "Rope")
                {
                    continue;
                }

                gameObject.Value.SetActive(true);
            }
        }
        else
        {
            foreach (var gameObject in dave_Attack_Help_Object)
            {
                if (gameObject.Key == "Rope")
                {
                    gameObject.Value.SetActive(true);
                    gameObject.Value.GetComponent<LineRenderer>().enabled = true;

                }
                if(gameObject.Key== "Target_Curve")
                {
                    gameObject.Value.SetActive(false);
                }
                if(gameObject.Key == "Target_ArrowGun")
                {
                    gameObject.Value.SetActive(false);
                }
                if (gameObject.Key == "Harpon_Head")
                {
                    gameObject.Value.SetActive(true);
                }             
            }                
        }

      
      

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
