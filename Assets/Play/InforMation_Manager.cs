//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//using Newtonsoft.Json;
//using System.Text;

////public class Clownfish_Information
////{
////    public string picture;
////    public string name = "adsd";
////    public string weight;
////    public string rank;
////    public int meat; 
////}

////public class Comber_Information
////{
////    public string picture;
////    public string name = "adsd";
////    public string weight;
////    public string rank;
////    public int meat;
////}

////public class Ruby_CardinalFish_Information
////{
////    public string picture;
////    public string name = "adsd";
////    public string weight;
////    public string rank;
////    public int meat;
////}

////public class Yellow_Tang_Information 
////{
////    public string picture;
////    public string name = "adsd";
////    public string weight;
////    public string rank;
////    public int meat;
////}

////public class Fish
////{
////    public string picture;
////    public string name = "adsd";
////    public string weight;
////    public string rank;
////    public int meat;
////}

////public class Fish
////{
////    Fish[] fish;
////}



//public class InforMation_Manager : MonoBehaviour
//{
//    public int a = 0;


//    void Start()
//    {
       
//        FileStream Stream = new FileStream(Application.dataPath + "/test.json", FileMode.Open);
//        byte[] date = new byte[Stream.Length];
//        Stream.Read(date, 0, date.Length);
//        Stream.Close();
//        string jsondate = Encoding.UTF8.GetString(date);
//        Fish_Manager fish = JsonConvert.DeserializeObject<Fish_Manager>(jsondate);
//        print(fish);


  
//    }

//    private void Update()
//    {
    
//    }

//}