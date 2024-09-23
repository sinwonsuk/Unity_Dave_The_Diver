using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class Slot : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI fish_name;
    [SerializeField]
    TextMeshProUGUI rank;
    [SerializeField]
    TextMeshProUGUI meat;
    [SerializeField]
    TextMeshProUGUI weight;
    [SerializeField]
    Image fish_image;



    public GameObject Create_Prefab(Dictionary<string, Json_Manager.Fish> _fishDictionary, string name,Transform _transform)
    {       
        if(_fishDictionary.ContainsKey(name))                
        {
            GameObject slotobject = Instantiate(gameObject, _transform);
            Json_Manager.Fish _fish = _fishDictionary[name];
            Slot slot = slotobject.GetComponent<Slot>();
            slot.init(_fish);

            return slotobject;
        }        
        return null;
    }

    void init(Json_Manager.Fish _fish)
    {                     
            fish_name.text = _fish.name;
            rank.text = _fish.rank;
            meat.text = _fish.meat.ToString();
            weight.text = _fish.weight;
            _fish.count += 1;
            _fish.today_count += 1;
            fish_image.sprite = Resources.Load<Sprite>(_fish.picture);          
    }

    void Start()
    {
       
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
