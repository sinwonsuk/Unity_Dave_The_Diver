using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sushi_Recipe : MonoBehaviour
{
    // Start is called before the first frame update

    List<Vector2> list = new List<Vector2>();

    //GameObject prefabInstance;

    float plusX = 85.0f;
    float plusY = 86.0f;

    int plusCountX = -1;
    int plusCountY = 0;



    public void Make_PreFab(Transform _transform , List<GameObject> _PreFab)
    {
        if (Json_Manager.Get_Instance() == null)
        {
            return;
        }

        // ¿Ã«ÿ æ»µ  
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


            if (plusCountX == -1)
            {
                for (int i = 0; i < prefabInstance.transform.childCount; i++)
                {
                    prefabInstance.transform.GetChild(i).gameObject.SetActive(true);
                }
            }


            prefabInstance.GetComponent<RectTransform>().anchoredPosition = new Vector2(-126.0f, 304.0f);

            prefabInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = fish.Value.sushi_Level;
            prefabInstance.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(fish.Value.sushi_file_path);

            prefabInstance.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = fish.Value.count.ToString();
            prefabInstance.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = fish.Value.sushi_Name;

            prefabInstance.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = fish.Value.sushi_Level;
            prefabInstance.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = fish.Value.price;
            prefabInstance.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = fish.Value.happy;
            prefabInstance.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = fish.Value.food;

            prefabInstance.transform.GetChild(8).GetComponent<Image>().sprite = Resources.Load<Sprite>(fish.Value.sushi_file_path);

            {
                prefabInstance.transform.GetChild(9).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(fish.Value.picture);
                prefabInstance.transform.GetChild(9).GetChild(1).GetComponent<TextMeshProUGUI>().text = fish.Value.count.ToString();
                prefabInstance.transform.GetChild(9).GetChild(2).GetComponent<TextMeshProUGUI>().text = fish.Value.name;
            }

            TransformCalculate(prefabInstance);
        }


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


        int ad = 0;

        for (int i = 3; i < transform.childCount; i++)
        {
            Vector2 vector = list[ad];

            if (plusCountX > 3)
            {
                vector.y += plusY * plusCountY;
                vector.x = list[ad].x;
            }
            else
            {
                vector.x -= plusX * plusCountX;
            }
            ad += 1;
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
