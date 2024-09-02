using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Today_Sushi_Menu_Info : MonoBehaviour
{
    GameObject Instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
    public void Make_PreFab(string _Name, Transform _transform, int _count)
    {


        Dictionary<string, Json_Manager.Fish> fishDictionary = Json_Manager.Get_Instance().GetFishList().fishDictionary;

        foreach (var fish in fishDictionary)
        {
            if (fish.Key == _Name)
            {
                transform.Find("Sushi_Picture").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(fish.Value.sushi_file_path);
                transform.Find("Sushi_Name").gameObject.GetComponent<TextMeshProUGUI>().text = fish.Value.sushi_Name;
                transform.Find("Sushi_Happy").gameObject.GetComponent<TextMeshProUGUI>().text = fish.Value.happy;
                transform.Find("Sushi_Count").gameObject.GetComponent<TextMeshProUGUI>().text = _count.ToString();
                transform.Find("Sushi_Count_02").gameObject.GetComponent<TextMeshProUGUI>().text = _count.ToString();

                int temp = int.Parse(fish.Value.price);

                int Money = temp * _count;

                transform.Find("Sushi_Price").gameObject.GetComponent<TextMeshProUGUI>().text = Money.ToString();
                Instance = Instantiate(gameObject, _transform);

                //string jsonData = JsonUtility.ToJson(Json_Manager.Get_Instance().GetFishList(), true);
                //string path = Path.Combine(Application.dataPath + "/Resources", "test.json");
                //File.WriteAllText(path, jsonData);

                return;
            }
        }


        //if (fishDictionary.keys == name)
        //{


        //}
    }
}
