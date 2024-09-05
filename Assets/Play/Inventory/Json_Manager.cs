using Newtonsoft.Json;

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class Json_Manager : MonoBehaviour
{
    private static Json_Manager json_Manager_Instance = null;

    public static Json_Manager Get_Instance()
    {     
        if(json_Manager_Instance == null)
        {
            json_Manager_Instance= FindObjectOfType<Json_Manager>();
        }

        return json_Manager_Instance;
    }



    [System.Serializable]
    public class Fish
    {
        public string picture;
        public string name;
        public string weight;
        public string rank;
        public int meat;
        public int count;
        public string price;
        public string happy;
        public string food;
        public string sushi_file_path;
        public string sushi_Name;
        public string sushi_Level;
        public int today_count;
    }
        
    [System.Serializable]
    public class FishList
    {
        public Fish[] fishlist_array;
        public Dictionary<string, Fish> fishDictionary = new Dictionary<string, Fish>();
    }

    public TextAsset asset;

    FishList fishlist = new FishList();

   
    public FishList GetFishList()
    {    
        return fishlist;    
    }

    private void Awake()
    {
        json_Manager_Instance = this;

        fishlist = JsonUtility.FromJson<FishList>(asset.text);
     
        for (int i = 0; i < fishlist.fishlist_array.Length; i++)
        {
            fishlist.fishDictionary.Add(fishlist.fishlist_array[i].name, fishlist.fishlist_array[i]);
        }       
    }

}
