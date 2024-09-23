using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Json_Manager;
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

    public void Make_Prefabs(Transform _transformParent)
    {
        Dictionary<string, Json_Manager.Fish> _fishDictionary  =Json_Manager.Get_Instance().GetFishList().fishDictionary;

        foreach (var fish in _fishDictionary)
        {
            if(fish.Value.today_count > 0)
            {
                GameObject slotobject = Instantiate(gameObject, _transformParent);

                Sea_Slot slot = slotobject.GetComponent<Sea_Slot>();

                slot.Init(fish.Value);              
            }
        }
    }

    void Init(Json_Manager.Fish _fish)
    {
        fish_Sprite.sprite = Resources.Load<Sprite>(_fish.picture);
        sushi_Sprite.sprite = Resources.Load<Sprite>(_fish.sushi_file_path);
        fish_Name.text = _fish.name;
        money.text = _fish.price;
        meat.text = _fish.today_count.ToString();
    }

    void Update()
    {
        
    }


}
