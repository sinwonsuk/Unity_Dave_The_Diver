using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea_Inven_Control : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject slot;

    [SerializeField]
    Transform transformParent;

    [SerializeField]
    GameObject scroll_View;

    [SerializeField]
    GameObject scroll;

    [SerializeField]
    GameObject bancho_reaction;

    [SerializeField]
    Sea_Dave sea_dave;




    private void OnEnable()
    {
            
    }

    public void Slotopen()
    {
        slot.GetComponent<Sea_Slot>().Make_Prefabs(transformParent);
    }


    private void OnDisable()
    {      
        scroll_View.SetActive(false);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && sea_dave.Night_Aftroon_check ==true)
        {
            scroll_View.SetActive(false);
            bancho_reaction.SetActive(true);
        }



    }
}
