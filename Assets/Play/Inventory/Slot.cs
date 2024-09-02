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




public class Slot : MonoBehaviour
{





   

    public void Information_Send(Dictionary<string, Json_Manager.Fish> _fishDictionary, string name)
    {
        foreach (var fish in _fishDictionary)
        {
            if(fish.Key == name)
            {
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = fish.Value.name;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = fish.Value.rank;
                transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = fish.Value.meat.ToString();
                transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = fish.Value.weight;
                fish.Value.count += 1;
                fish.Value.today_count += 1;
                transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>(fish.Value.picture);

                string jsonData = JsonUtility.ToJson(Json_Manager.Get_Instance().GetFishList(),true);
                string path = Path.Combine(Application.dataPath+ "/Resources", "test.json");
                File.WriteAllText(path, jsonData);

            }

        }


    }



    void Start()
    {
       
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
