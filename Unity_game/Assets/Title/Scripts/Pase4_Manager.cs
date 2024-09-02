using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pase4_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator Animator;

    public Image ballon;
    public Image cobra;
    public float Alpha = 0.0f;

    public GameObject dave_Arm;

    //Image image = GetComponent<Image>();

    //image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);

    void Start()
    {
        
        ballon.color = new Color(ballon.color.r, ballon.color.g, ballon.color.b, 0.0f);
        cobra.color = new Color(ballon.color.r, ballon.color.g, ballon.color.b, 0.0f);
        Animator.SetBool("test", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Alpha += Time.deltaTime * 2;

            ballon.color = new Color(ballon.color.r, ballon.color.g, ballon.color.b, Alpha);
            cobra.color = new Color(ballon.color.r, ballon.color.g, ballon.color.b, Alpha);


            //ballon.SetActive(true);
            //cobra.SetActive(true);
        }

        if (Alpha > 5.0)
        {
            Animator.SetBool("test", true);
            dave_Arm.SetActive(true);
        }
       
    }
}
