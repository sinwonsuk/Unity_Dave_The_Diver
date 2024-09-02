using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dive_Log_Fill : MonoBehaviour
{
    // Start is called before the first frame update

    Image image;
    bool audio_check = false;
    void Start()
    {
        image = GetComponent<Image>();


    }

    private void OnDisable()
    {
        audio_check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(image.fillAmount >= 1)
        {
            return;
        }


        if(Input.GetKey(KeyCode.Space))
        {
            if(audio_check ==false)
            {
                Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_lobby_dive, true,0.6f);
                audio_check = true;
            }

            image.fillAmount += Time.deltaTime*0.5f;
        }
        else 
        {
            if(audio_check ==true)
            {
                Audio_Manager.GetInstance().Sfx_Stop(Audio_Manager.sfx.ui_lobby_dive);
                audio_check = false;
            }


            image.fillAmount -= Time.deltaTime;
        }


    }
}
