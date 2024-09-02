using Newtonsoft.Json;

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using UnityEngine;

public class Json_Manager : MonoBehaviour
{
    private static Json_Manager json_Manager_Instance = null;

    public static Json_Manager Get_Instance()
    {
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
        public Fish[] fishlist;
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

       

        for (int i = 0; i < fishlist.fishlist.Length; i++)
        {
            fishlist.fishDictionary.Add(fishlist.fishlist[i].name, fishlist.fishlist[i]);
        }

        
    }

    public void Start()
    {
       



        //FileStream Stream = new FileStream(Application.dataPath + "/test.json", FileMode.Open);
        //byte[] date = new byte[Stream.Length];
        //Stream.Read(date, 0, date.Length);
        //Stream.Close();
        //string jsondate = Encoding.UTF8.GetString(date);
        //fish = JsonConvert.DeserializeObject<Fish_Manager>(jsondate);

       


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
