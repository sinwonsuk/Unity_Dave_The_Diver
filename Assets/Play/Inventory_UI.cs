using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Json_Manager;


public class Inventory_UI : MonoBehaviour
{
    List<GameObject> prefab = new List<GameObject>();

    [SerializeField]
    private GameObject parent_Transform;

    [SerializeField]
    private GameObject Slot;


    public void Fish_Inventory_Move(Dictionary<string, Fish> _fishDictionary,string name)
    {                    
        foreach (var fish in _fishDictionary)
        {
           if(fish.Key == name)
           {               
                GameObject gameObject = Slot.GetComponent<Slot>().Create_Prefab(_fishDictionary, name, parent_Transform.transform);
                prefab.Add(gameObject); 
           }
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < prefab.Count; i++)
        {       
            Destroy(prefab[i]);
        }

        prefab.Clear();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
