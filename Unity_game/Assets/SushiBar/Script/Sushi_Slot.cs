using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Json_Manager;


public class Sushi_Slot : MonoBehaviour
{
    [SerializeField]
    Image Fish_Sprite;

    [SerializeField]
    Image Sushi_Sprite;

    [SerializeField]
    TextMeshProUGUI Fish_Name;

    [SerializeField]
    TextMeshProUGUI Sushi_Count;

    [SerializeField]
    TextMeshProUGUI Make_Count_02;

    [SerializeField]
    TextMeshProUGUI Make_Count;

    [SerializeField]
    TextMeshProUGUI Make_Count_03;

    [SerializeField]
    TextMeshProUGUI Sushi_Name;



    int count = 0;

    GameObject Instance;

   



    // Start is called before the first frame update
    public void destory()
    {
       
    }

    public void Make_PreFab(string _Name,Transform _transform, ref GameObject temp)
    {
        

        Dictionary<string, Json_Manager.Fish> fishDictionary = Json_Manager.Get_Instance().GetFishList().fishDictionary;

        foreach (var fish in fishDictionary)
        {
            if (fish.Key == _Name)
            {

                Fish_Sprite.sprite = Resources.Load<Sprite>(fish.Value.picture);
                Sushi_Sprite.sprite = Resources.Load<Sprite>(fish.Value.sushi_file_path);
                Fish_Name.text = fish.Value.name;
                Sushi_Count.text = fish.Value.count.ToString();
                Make_Count_02.text = count.ToString();
                Make_Count.text = count.ToString();
                Make_Count_03.text = count.ToString();
                Sushi_Name.text = fish.Value.sushi_Name;
                Instance = Instantiate(gameObject, _transform);


                temp = Instance;
                return;
            }
        }


        //if (fishDictionary.keys == name)
        //{


        //}
    }


    private void Start()
    {
        





    }

    void textView()
    {
        transform.Find("Make_Count").gameObject.GetComponent<TextMeshProUGUI>().text = count.ToString();
        transform.Find("Make_Count_02").gameObject.GetComponent<TextMeshProUGUI>().text = count.ToString();
        transform.Find("Make_Count_03").gameObject.GetComponent<TextMeshProUGUI>().text = count.ToString();
    }



    public int Food_Add_Mus()
    {
       

        


        if (Input.GetKeyDown(KeyCode.D))
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);
            count += 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);
            count -= 1;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);
            count = int.Parse(transform.Find("Sushi_Count").gameObject.GetComponent<TextMeshProUGUI>().text);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_button_click, false);
            count = 0;
        }


        if (count > int.Parse(transform.Find("Sushi_Count").gameObject.GetComponent<TextMeshProUGUI>().text))
        {
            count = int.Parse(transform.Find("Sushi_Count").gameObject.GetComponent<TextMeshProUGUI>().text);
        }

        if (count < 0)
        {
            count = 0;
        }

        textView();

        return count;

       
    }
    public void Count_Change_And_Destory(GameObject _Prefab, string _name)
    {
        
            Dictionary<string, Json_Manager.Fish> fishDictionary = Json_Manager.Get_Instance().GetFishList().fishDictionary;
         
         
            fishDictionary[_name].count -= count;
         
         
               
            _Prefab.transform.Find("Sushi_Recipe_Info").Find("Meat_Count").GetComponent<TextMeshProUGUI>().text = fishDictionary[_name].count.ToString();
            _Prefab.transform.Find("Sushi_Count_Font").GetComponent<TextMeshProUGUI>().text = fishDictionary[_name].count.ToString();
         
            count = 0;
         
            Destroy(gameObject);
       
    }


    // Update is called once per frame
    void Update()
    {
     //   Dictionary<string, Json_Manager.Fish> fishDictionary = Json_Manager.Get_Instance().GetFishList().fishDictionary;

        //foreach (var fish in fishDictionary)
        //{
        //    if (fish.Key == "Comber")
        //    {
        //        transform.Find("Fish_Sprite").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(fish.Value.picture);
        //        transform.Find("Sushi_Sprite").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(fish.Value.sushi_file_path);
        //        transform.Find("Fish_Name").gameObject.GetComponent<TextMeshProUGUI>().text = fish.Value.name;
        //        transform.Find("Sushi_Count").gameObject.GetComponent<TextMeshProUGUI>().text = fish.Value.count.ToString();
        //        transform.Find("Make_Count").gameObject.GetComponent<TextMeshProUGUI>().text = count.ToString();
        //        transform.Find("Make_Count_02").gameObject.GetComponent<TextMeshProUGUI>().text = count.ToString();
        //        transform.Find("Make_Count_03").gameObject.GetComponent<TextMeshProUGUI>().text = count.ToString();
        //        transform.Find("Sushi_Name").gameObject.GetComponent<TextMeshProUGUI>().text = fish.Value.sushi_Name;
               
        //        return;
        //    }
        //}




    }
}
