using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static Json_Manager;




public class Slot : MonoBehaviour
{

    public GameObject Create_Prefab(Dictionary<string, Json_Manager.Fish> _fishDictionary, string name,Transform _transform)
    {
        if(_fishDictionary.ContainsKey(name))                
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _fishDictionary[name].name;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _fishDictionary[name].rank;
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _fishDictionary[name].meat.ToString();
            transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = _fishDictionary[name].weight;
            _fishDictionary[name].count += 1;
            _fishDictionary[name].today_count += 1;
            transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>(_fishDictionary[name].picture);
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
