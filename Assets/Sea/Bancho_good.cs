using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bancho_good : MonoBehaviour
{

    [SerializeField]
    GameObject banCho_Open;

    bool audioCheck =false;

    Vector2 vector2 = new Vector2(0, 0);
    float time = 0;
    bool big_Small = false;
    public float speed = 1;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();  
    }

    private void OnDisable()
    {
        vector2 = new Vector2(0, 0);
        time = 0;
        big_Small = false;
        audioCheck = false;
        gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (big_Small == false)
        {
            vector2.x += Time.deltaTime * speed;
            vector2.y += Time.deltaTime * speed;


            if (vector2.x < 1.0f)
            {
                image.rectTransform.localScale = vector2;
            }
            else
            {
                big_Small = true;
            }
        }

        if (big_Small == true)
        {
            time += Time.deltaTime;

            if (time > 1)
            {
                vector2.x -= Time.deltaTime * speed;
                vector2.y -= Time.deltaTime * speed;

                image.rectTransform.localScale = vector2;

            }

            if (image.rectTransform.localScale.x <= 0)
            {
                Vector2 vector = new Vector2(0, 0);

                image.rectTransform.localScale = vector;
                if (audioCheck == false)
                {
                     Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_lobby_sushi_openpopup, false);
                    audioCheck = true;
                }
               
                banCho_Open.SetActive(true);    
            }



        }
    }
}
