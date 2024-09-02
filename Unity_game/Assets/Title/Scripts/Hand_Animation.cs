using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Animation : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;
    public GameObject Alpha_Object;
    float Speed = 150.0f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            transform.Translate(new Vector3(0.0f, Speed*Time.deltaTime, 0.0f));
        }

        if(transform.localPosition.y >= 588.0f)
        {
            Alpha_Object.SetActive(true);
        }

     


    }
}
