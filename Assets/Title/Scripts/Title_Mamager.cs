
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class Title_Mamager : MonoBehaviour
{


    [SerializeField]
    private List<GameObject> animations = new List<GameObject>();

    float time = 0.0f;

    int Pass = 1;

    void Change_Animation()
    {
        if (Pass == animations.Count)
        {
            return;
        }

        time += Time.deltaTime;

        if (time > 8.0f)
        {
            int count = animations.Count;
           
            if (count < Pass)
            {
                return;
            }

            int Prev_Pass = Pass-1;

            animations[Prev_Pass].SetActive(false);
        
            animations[Pass].SetActive(true);

            Pass++;
            time = 0;
        }
    }
   






    // Start is called before the first frame update
    void Start()
    {
        Audio_Manager.GetInstance().PlayBgm(Audio_Manager.bgm.Intro);
    }

    // Update is called once per frame
    void Update()
    {

        Change_Animation();




       // image.sprite.
    }
}
