using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Json_Manager;

public class Sushi_Recipe : MonoBehaviour
{


    List<Vector2> list = new List<Vector2>();

    float plusX = 85.0f;
    float plusY = 86.0f;

    int plusCountX = -1;
    int plusCountY = 0;

    [SerializeField]
    TextMeshProUGUI sushi_Level;
    [SerializeField]
    Image sushi_file_path;
    [SerializeField]
    TextMeshProUGUI fish_count;
    [SerializeField]
    TextMeshProUGUI sushi_Name;
    [SerializeField]
    TextMeshProUGUI sushi_Level_02;
    [SerializeField]
    TextMeshProUGUI fish_price;
    [SerializeField]
    TextMeshProUGUI fish_happy;
    [SerializeField]
    TextMeshProUGUI fish_food;
    [SerializeField]
    Image sushi_file_path_02;
    [SerializeField]
    Image fish_picture;
    [SerializeField]
    TextMeshProUGUI fish_count_02;
    [SerializeField]
    TextMeshProUGUI fish_name;

    public void Make_PreFab(Transform _transform , List<GameObject> _PreFab)
    {
        if (Json_Manager.Get_Instance() == null)
        {
            return;
        }

        plusCountX = -1;
        plusCountY = 0;

        for (int i = 3; i < transform.childCount; i++)
        {
            Vector2 temp = transform.GetChild(i).gameObject.GetComponent<RectTransform>().anchoredPosition;

            list.Add(temp);
        }

        Dictionary<string, Json_Manager.Fish> fishDictionary = Json_Manager.Get_Instance().GetFishList().fishDictionary;

        foreach (var fish in fishDictionary)
        {
            GameObject prefabInstance = Instantiate(gameObject, _transform);


            _PreFab.Add(prefabInstance);


            Sushi_Recipe sushi_Recipe = prefabInstance.GetComponent<Sushi_Recipe>();

            sushi_Recipe.init(fish.Value);

            //if (plusCountX == -1)
            //{
            //    for (int i = 0; i < prefabInstance.transform.childCount; i++)
            //    {
            //        prefabInstance.transform.GetChild(i).gameObject.SetActive(true);
            //    }
            //}


            //prefabInstance.GetComponent<RectTransform>().anchoredPosition = new Vector2(-126.0f, 304.0f);




            TransformCalculate(prefabInstance);
        }


    }

    void init(Json_Manager.Fish fish)
    {
        sushi_Level.text = fish.sushi_Level;
        sushi_file_path.sprite = Resources.Load<Sprite>(fish.sushi_file_path);
        fish_count.text = fish.count.ToString();
        sushi_Name.text = fish.sushi_Name;
        sushi_Level_02.text = fish.sushi_Level;
        fish_price.text = fish.price;
        fish_happy.text = fish.happy;
        fish_food.text = fish.food;
        sushi_file_path_02.sprite = Resources.Load<Sprite>(fish.sushi_file_path);
        fish_picture.sprite = Resources.Load<Sprite>(fish.picture);
        fish_count_02.text = fish.count.ToString();
        fish_name.text = fish.name;

    }


    void TransformCalculate(GameObject prefabInstance)
    {
        plusCountX++;

        if (plusCountX <= 0)
        {
            return;
        }

        Vector2 vector2 = prefabInstance.gameObject.GetComponent<RectTransform>().anchoredPosition;

        vector2.x += plusX * plusCountX;

        if (plusCountX > 3)
        {

            plusCountY++;
            vector2.y -= plusY * plusCountY;
            vector2.x = -126.0f;
        }


        prefabInstance.gameObject.GetComponent<RectTransform>().anchoredPosition = vector2;


        int index = 0;

        for (int i = 3; i < transform.childCount; i++)
        {
            Vector2 vector = list[index];

            if (plusCountX > 3)
            {
                vector.y += plusY * plusCountY;
                vector.x = list[index].x;
            }
            else
            {
                vector.x -= plusX * plusCountX;
            }
            index += 1;
            prefabInstance.transform.GetChild(i).gameObject.GetComponent<RectTransform>().anchoredPosition = vector;
        }


    }
    private void OnDisable()
    {
        //Destroy(gameObject);
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
