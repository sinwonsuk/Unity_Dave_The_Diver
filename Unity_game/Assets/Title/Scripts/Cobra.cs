using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cobra : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;

    Image image;

    public GameObject shusi;
    void Start()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
        animator.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (image.color.a >= 1)
        {
            //animator.SetBool("Title_Pase4_Cobra", true);
            animator.enabled = true;
        }



        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime>=1)
        {
            shusi.SetActive(true);
        }
    }
}
