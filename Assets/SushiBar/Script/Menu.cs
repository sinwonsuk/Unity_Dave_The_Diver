using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

        foreach (var fish in fishDictionary)
        {
            if (fish.Key == _Name)
            {
               
                sushi_Sprite.sprite = Resources.Load<Sprite>(fish.Value.sushi_file_path);
                text_Count.text = _Count.ToString();
                sushi_Count.text = _Count.ToString();
                GameObject instance = Instantiate(gameObject, _transform);

                instance.GetComponent<Menu>().count = _Count;
                instance.GetComponent<Menu>().sushi_path = fish.Value.sushi_file_path;

                return;
            }
        }
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
