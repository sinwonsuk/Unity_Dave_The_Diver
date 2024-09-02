using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using static UnityEngine.Mesh;

public class Scene_Manager : MonoBehaviour
{

    static Scene_Manager instance;

    [SerializeField]
    List<GameObject> scenes = new List<GameObject>();  

    Dictionary<string, GameObject> scenesdictionary = new Dictionary<string, GameObject>();

    [SerializeField]
    GameObject sea_Night_Alpha;
    [SerializeField]
    GameObject sea_Light;

    [SerializeField]
    GameObject sea_Light_02;

    [SerializeField]
    GameObject sea_inventory_scroll;

    [SerializeField]
    GameObject sea_inventory;


    [SerializeField]
    MeshRenderer sea_sky;



    [SerializeField]
    PostProcessVolume postProcessVolume;
    [SerializeField]
    Bloom bloom;

    public bool aftroon_or_night_Check { get; set; }


    // Start is called before the first frame update

    private void Awake()
    {
        aftroon_or_night_Check = false;

        instance = this;
    }


    void Start()
    {       
        for (int i = 0; i < scenes.Count; i++)
        {
            scenesdictionary.Add(scenes[i].name, scenes[i]);
        }

        postProcessVolume.profile.TryGetSettings(out bloom);
     
    }

    public static Scene_Manager Getinstance()
    {
        return instance;
    }

    public void Change_from_Title_to_sea()
    {
        scenesdictionary["Title"].SetActive(false);
        scenesdictionary["SushiBar"].SetActive(false);
        scenesdictionary["Sea"].SetActive(true);
        scenesdictionary["Play"].SetActive(false);
    }

    public void Change_from_dive_to_sea()
    {
        scenesdictionary["Title"].SetActive(false);
        scenesdictionary["SushiBar"].SetActive(false);
        scenesdictionary["Sea"].SetActive(true);
        scenesdictionary["Play"].SetActive(false);


        Material newMaterial = Resources.Load<Material>("Sky/Night_Sky");

        if (newMaterial != null)
        {
            sea_sky.material = newMaterial;
            // 이게 낮나 아니면 그냥 인스팩터창에서 연결하는게 좋나? 
            // scenesdictionary["Sea"].transform.Find("Canvas").FindChild("adadada");
        }
        Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_lobby_open, false);
        sea_inventory_scroll.SetActive(true);
        sea_Night_Alpha.SetActive(true);
        sea_Light.SetActive(false);
        sea_Light_02.SetActive(false);
        bloom.intensity.value = 0.2f;
        RenderSettings.fog = false;
        aftroon_or_night_Check = true;
        sea_inventory.GetComponent<Sea_Inven_Control>().Slotopen();
    }


    public void Change_from_sea_to_dive()
    {
        scenesdictionary["Title"].SetActive(false);
        scenesdictionary["SushiBar"].SetActive(false);
        scenesdictionary["Sea"].SetActive(false);
        scenesdictionary["Play"].SetActive(true);

      
        bloom.intensity.value = 1.8f;
        RenderSettings.fog = true;
    }

    public void Change_from_sea_to_SushiBar()
    {
        scenesdictionary["Title"].SetActive(false);
        scenesdictionary["SushiBar"].SetActive(true);
        scenesdictionary["Sea"].SetActive(false);
        scenesdictionary["Play"].SetActive(false);
        sea_inventory_scroll.SetActive(false);
        RenderSettings.fog = false;
    }



    public void Change_from_SushiBar_to_Sea()
    {
        scenesdictionary["Title"].SetActive(false);
        scenesdictionary["SushiBar"].SetActive(false);
        scenesdictionary["Sea"].SetActive(true);
        scenesdictionary["Play"].SetActive(false);


        Material newMaterial = Resources.Load<Material>("Sky/Afternoon_Sky");

        if (newMaterial != null)
        {
            sea_sky.material = newMaterial;
            // 이게 낮나 아니면 그냥 인스팩터창에서 연결하는게 좋나? 
            // scenesdictionary["Sea"].transform.Find("Canvas").FindChild("adadada");
        }

        sea_inventory_scroll.SetActive(false);
        sea_Night_Alpha.SetActive(false);
        sea_Light.SetActive(true);
        sea_Light_02.SetActive(true);
        bloom.intensity.value = 1.2f;
        RenderSettings.fog = false;

        aftroon_or_night_Check = false;
    }



    public void TitleOn()
    {
        scenesdictionary["Title"].SetActive(true);      
        scenesdictionary["SushiBar"].SetActive(false);
        scenesdictionary["Sea"].SetActive(false);
        scenesdictionary["Play"].SetActive(false);
        scenesdictionary["start_Scene"].SetActive(false);
    }

    //public void SushiBarOn()
    //{
    //    scenesdictionary["Title"].SetActive(false);
    //    scenesdictionary["SushiBar"].SetActive(true);
    //    scenesdictionary["Sea"].SetActive(false);
    //    scenesdictionary["Play"].SetActive(false);
    //}

    //public void SeaOn()
    //{       
    //    scenesdictionary["Title"].SetActive(false);
    //    scenesdictionary["SushiBar"].SetActive(false);
    //    scenesdictionary["Sea"].SetActive(true);
    //    scenesdictionary["Play"].SetActive(false);

    //    RenderSettings.fog = false;
    //}

    //public void PlayOn()
    //{
    //    scenesdictionary["Title"].SetActive(false);
    //    scenesdictionary["SushiBar"].SetActive(false);
    //    scenesdictionary["Sea"].SetActive(false);
    //    scenesdictionary["Play"].SetActive(true);

    //    RenderSettings.fog = true;

    //}

    void OnApplicationQuit()
    {
       
            Dictionary<string, Json_Manager.Fish> _fishDictionary = Json_Manager.Get_Instance().GetFishList().fishDictionary;

            foreach (var fish in _fishDictionary)
            {                                               
                    fish.Value.today_count = 0;                                       
            }

        string jsonData = JsonUtility.ToJson(Json_Manager.Get_Instance().GetFishList(), true);
        string path = Path.Combine(Application.dataPath + "/Resources", "test.json");
        File.WriteAllText(path, jsonData);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
