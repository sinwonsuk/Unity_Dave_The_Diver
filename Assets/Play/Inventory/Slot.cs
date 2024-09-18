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
            fish_name.text = _fishDictionary[name].name;
            rank.text = _fishDictionary[name].rank;
            meat.text = _fishDictionary[name].meat.ToString();
            weight.text = _fishDictionary[name].weight;
            _fishDictionary[name].count += 1;
            _fishDictionary[name].today_count += 1;
            fish_image.sprite = Resources.Load<Sprite>(_fishDictionary[name].picture);
            return Instantiate(gameObject, _transform);
        }     
        return null;
    }



    void Start()
    {
       
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
