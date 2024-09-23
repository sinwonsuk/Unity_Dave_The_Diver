using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Json_Manager;
public class Menu : MonoBehaviour
{



    [SerializeField]
    Image sushi_Sprite;

    [SerializeField]
    TextMeshProUGUI text_Count;

    [SerializeField]
    TextMeshProUGUI sushi_Count;


    public TextMeshProUGUI Get_text_Count()
    {
        return text_Count;
    }



    string sushi_path;

    int count;

    public int Get_count()
    {
        return count;
    }

    public void Set_Mus_count(int _count)
    {
        count -= _count;
    }
    public string Get_sushi_path()
    {
        return sushi_path;
    }

    public TextMeshProUGUI Get_Text_count()
    {
        return text_Count;
    }


    private void OnDisable()
    {
        Destroy(gameObject);    
    }


    public void Make_PreFab(string _Name, Transform _transform,int _Count)
    {

        Dictionary<string, Json_Manager.Fish> fishDictionary = Json_Manager.Get_Instance().GetFishList().fishDictionary;
     
        if(fishDictionary.ContainsKey(_Name))
        {
            GameObject instance = Instantiate(gameObject, _transform);
            Menu menu = instance.GetComponent<Menu>();
            Json_Manager.Fish fish = fishDictionary[name];
            menu.Init(fish, _Count);      
            return;
        }
        
    }

    void Init(Json_Manager.Fish fish,int _count)
    {
        sushi_Sprite.sprite = Resources.Load<Sprite>(fish.sushi_file_path);
        text_Count.text = _count.ToString();
        sushi_Count.text = _count.ToString();
        count = _count;
        sushi_path = fish.sushi_file_path;
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int a= count;
    }
}
