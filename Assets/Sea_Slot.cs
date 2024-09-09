using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
public class Sea_Slot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Image fish_Sprite;

    [SerializeField]
    TextMeshProUGUI fish_Name;

    [SerializeField]
    Image sushi_Sprite;

    [SerializeField]
    TextMeshProUGUI money;

    [SerializeField]
    TextMeshProUGUI meat;


    private void OnDisable()
    {
        Destroy(gameObject);    
    }
    void Start()
    {
        
    }

    public void Make_Prefab(Transform _transformParent)
    {
        Dictionary<string, Json_Manager.Fish> _fishDictionary  =Json_Manager.Get_Instance().GetFishList().fishDictionary;

        foreach (var fish in _fishDictionary)
        {
            if(fish.Value.today_count > 0)
            {
                fish_Sprite.sprite = Resources.Load<Sprite>(fish.Value.picture);
                sushi_Sprite.sprite = Resources.Load<Sprite>(fish.Value.sushi_file_path);
                fish_Name.text = fish.Value.name;
                money.text = fish.Value.price;
                meat.text = fish.Value.today_count.ToString();

                Instantiate(gameObject, _transformParent);
            }
        }
    }
   
    void Update()
    {
        
    }


}
