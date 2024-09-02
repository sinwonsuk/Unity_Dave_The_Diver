using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sushi_trash : MonoBehaviour
{
    Image image;

    [SerializeField]
    GameObject parent_Object;

    [SerializeField]
    Animator dave_animator;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.B))
        {
            image.fillAmount += Time.deltaTime;
        }
       else
       {
            image.fillAmount -= Time.deltaTime;
       }

        if(image.fillAmount >=1)
        {
            dave_animator.SetTrigger("Back_Idle");
            parent_Object.SetActive(false);
        }

    }
}
