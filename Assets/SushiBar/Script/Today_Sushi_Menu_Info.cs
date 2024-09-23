using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Json_Manager;
public class Today_Sushi_Menu_Info : MonoBehaviour
{
    GameObject Instance;

    [SerializeField]
    Image sushi_Image;
    [SerializeField]
    TextMeshProUGUI sushi_Name;
    [SerializeField]
    TextMeshProUGUI fish_happy;
    [SerializeField]
    TextMeshProUGUI fish_Count;
    [SerializeField]
    TextMeshProUGUI fish_Count_02;
    [SerializeField]
    TextMeshProUGUI Sushi_Price;

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

    void init(Json_Manager.Fish fish, int _count)
    {
        sushi_Image.sprite = Resources.Load<Sprite>(fish.sushi_file_path);
        sushi_Name.text = fish.sushi_Name;
        fish_happy.text = fish.happy;
        fish_Count.text = _count.ToString();
        fish_Count_02.text = _count.ToString();  
        int temp = int.Parse(fish.price);
        int Money = temp * _count;
        Sushi_Price.text = Money.ToString();
        //string jsonData = JsonUtility.ToJson(Json_Manager.Get_Instance().GetFishList(), true);
        //string path = Path.Combine(Application.dataPath + "/Resources", "test.json");
        //File.WriteAllText(path, jsonData);
        return;

    }
    public void Make_PreFab(string _Name, Transform _transform, int _count)
    {


        Dictionary<string, Json_Manager.Fish> fishDictionary = Json_Manager.Get_Instance().GetFishList().fishDictionary;


        if(fishDictionary.ContainsKey(_Name)) 
        {
            GameObject _gameObject = Instantiate(gameObject, _transform);

            Today_Sushi_Menu_Info today_Sushi_Menu_Info = _gameObject.GetComponent<Today_Sushi_Menu_Info>();

            Json_Manager.Fish fish = fishDictionary[_Name];

            today_Sushi_Menu_Info.init(fish, _count);
            return;
        }

        
                
       
    }
}
