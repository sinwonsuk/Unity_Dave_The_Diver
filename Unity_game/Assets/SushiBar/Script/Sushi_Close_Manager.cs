using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi_Close_Manager : MonoBehaviour
{
    enum CloseState
    { 
      White_Up,
      Black_Active,
      White_Down,
      BanCho_Active,
      Font_Active,
      Font_Active_02,
      White,
    }


    float time = 0.0f;
    float speed = 200.0f;
    [SerializeField]
    Sushi_Alpha_Image sushi_Alpha_Image;

    [SerializeField]
    GameObject closeBlack;

    [SerializeField]
    GameObject banCho_Sprite;

    [SerializeField]
    GameObject banCho_Font;

    [SerializeField]
    GameObject closed_Font;

    [SerializeField]
    GameObject scene_Change;


    CloseState closeState = CloseState.White_Up;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        
    }


    private void OnDisable()
    {
        closeState = CloseState.White_Up;
        closeBlack.SetActive(false);
        banCho_Sprite.SetActive(false);

        for (int i = 0; i < banCho_Sprite.transform.childCount; i++)
        {
            banCho_Sprite.transform.GetChild(i).gameObject.SetActive(true);
        }


        banCho_Font.GetComponent<RectTransform>().anchoredPosition = new Vector2 (-89f, -11f);
        closed_Font.GetComponent<RectTransform>().anchoredPosition = new Vector2(-57.8f, -38f);

    }

    // Update is called once per frame
    void Update()
    {
        switch (closeState)
        {
            case CloseState.White_Up:
                {
                    if(sushi_Alpha_Image.alpha >=1)
                    {
                        sushi_Alpha_Image.alpha_Up_Down_Check = true;
                        closeState = CloseState.Black_Active;
                    }
                }
                break;
            case CloseState.Black_Active:
                {
                    closeBlack.SetActive(true);
                    closeState = CloseState.White_Down;
                }
                break;
            case CloseState.White_Down:
                {
                    if (sushi_Alpha_Image.alpha <= 0)
                    {                      
                        sushi_Alpha_Image.gameObject.SetActive(false);  
                        closeState = CloseState.BanCho_Active;
                    }
                }
                break;
            case CloseState.BanCho_Active:
                {
                    Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_sushibar_close, false);
                    banCho_Sprite.SetActive(true);
                    closeState = CloseState.Font_Active;
                }
                break;
            case CloseState.Font_Active:
                {




                    time += Time.deltaTime;

                    if(banCho_Font.GetComponent<RectTransform>().anchoredPosition.x < 0.0f)
                    {
                        banCho_Font.GetComponent<RectTransform>().anchoredPosition += Vector2.right * Time.deltaTime * speed;
                    }
                  
                    if(time > 1.0f && banCho_Font.GetComponent<RectTransform>().anchoredPosition.x >= 0.0f)
                    {
                        closeState = CloseState.Font_Active_02;
                        time = 0;
                    }
                }
                break;
            case CloseState.Font_Active_02:
                {
                    time += Time.deltaTime;

                    if (closed_Font.GetComponent<RectTransform>().anchoredPosition.x < 0.0f)
                    {
                        closed_Font.GetComponent<RectTransform>().anchoredPosition += Vector2.right * Time.deltaTime * speed;
                    }

                    if (time > 2.0f && banCho_Font.GetComponent<RectTransform>().anchoredPosition.x >= 0.0f)
                    {
                        closeState = CloseState.White;
                        time = 0;
                    }
                }
                break;
            case CloseState.White:
                {
                    scene_Change.SetActive(true);
                }
                break;


            default:
                break;
        }
    }
}
