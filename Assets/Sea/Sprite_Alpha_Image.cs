using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sprite_Alpha_Image : MonoBehaviour
{
    // Start is called before the first frame update

    SpriteRenderer spriteRenderer;
    Color Color;

    public enum Change_Scene
    { 
        Dive,
        Sushi

    }

    public Change_Scene change_Scene {  get; set; }



    private void Awake()
    {
       
    }
    private void OnDisable()
    {             
        Color.a = 0;
        spriteRenderer.color = new Color(1, 1, 1, 0);
    }

    void Start()
    {
    
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, 0);
        Color = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        Color.a += Time.deltaTime*0.5f;

        spriteRenderer.color = Color;   

        if(spriteRenderer.color.a >=1)
        {
            Audio_Manager.GetInstance().All_Sfx_Stop();
            Audio_Manager.GetInstance().Bgm_Stop();

            switch (change_Scene)
            {
                case Change_Scene.Dive:
                    {
                        gameObject.SetActive(false);

                        Scene_Manager.Getinstance().Change_from_sea_to_dive();
                    }
                    break;
                case Change_Scene.Sushi:
                    {
                        gameObject.SetActive(false);

                        Scene_Manager.Getinstance().Change_from_sea_to_SushiBar();
                    }
                    break;
                default:
                    break;
            }


             
        }

    }
}
