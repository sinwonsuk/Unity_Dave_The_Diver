using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
public class SushiBar_Scene_Change : MonoBehaviour
{
    [SerializeField]
    GameObject open_Start;

    Image image;

    float alpha = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        image.color = new Color(1, 1, 1, 0);
    }

    private void OnDisable()
    {
        open_Start.SetActive(true);
        alpha = 0;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        alpha += Time.deltaTime;


        if(alpha > 1)
        {
            Dictionary<string, Json_Manager.Fish> _fishDictionary = Json_Manager.Get_Instance().GetFishList().fishDictionary;


            foreach (var fish in _fishDictionary)
            {
                if (fish.Value.today_count > 0)
                {
                    fish.Value.today_count = 0;
                }
            }

            Scene_Manager.Getinstance().Change_from_SushiBar_to_Sea();
        
        }
        image.color = new Color(1, 1, 1, alpha);
    }
}
