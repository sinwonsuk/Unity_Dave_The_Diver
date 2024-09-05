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

    [SerializeField]
    private GameObject scrolBar_count;




    public void Fish_Inventory_Move(Dictionary<string, Fish> _fishDictionary,string name)
    {
            
        //Vector3 da = gameObjectsds[0].transform.position;
       
        foreach (var fish in _fishDictionary)
        {
           if(fish.Key == name)
           {
                if (scrolBar_count.transform.childCount == 9)
                {
                    RectTransform rectTransform = parent_Transform.transform.parent.parent.GetComponent<RectTransform>();
                    float temp = rectTransform.sizeDelta.y;
                    temp += 50.0f;
                    // 새로운 너비 설정 (기존 높이는 유지)
                    rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, temp);
                }

                if (scrolBar_count.transform.childCount > 9)
                {
                    RectTransform rectTransform = parent_Transform.transform.parent.parent.GetComponent<RectTransform>();
                    float temp = rectTransform.sizeDelta.y;
                    temp += 100.0f;
                    // 새로운 너비 설정 (기존 높이는 유지)
                    rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, temp);
                }



                Slot.GetComponent<Slot>().Information_Send(_fishDictionary, name);

                GameObject gameobject = Instantiate(Slot,parent_Transform.transform.parent);


                prefab.Add(gameobject);







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
