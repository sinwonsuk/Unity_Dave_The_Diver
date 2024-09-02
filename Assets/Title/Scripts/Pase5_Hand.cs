using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pase5_Hand : MonoBehaviour
{
    // Start is called before the first frame update

    float Speed = -150.0f;

   
    public GameObject hand_Animation;
    public GameObject Bag;


    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {

       

        //rectTransform.position.y
        if (transform.localPosition.y >= 236.0f)
        {
            transform.Translate(new Vector3(0, Speed * Time.deltaTime, 0));
        }
        else if(transform.localPosition.y <= 236.0f)
        {
            hand_Animation.SetActive(true);
            Bag.SetActive(false);
            gameObject.SetActive(false);

          
        }
        
        //if(Input.GetMouseButton(0))
        //{
        //    rectTransform.Translate(new Vector3(0, Speed * Time.deltaTime, 0));
        //}

    }
}
