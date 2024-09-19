using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cooking : MonoBehaviour
{
    // Start is called before the first frame update

    bool audio_Check = false;

    int childindex = 0;

    [SerializeField]
    Animator banCho;

    [SerializeField]
    Image dave_Sushi_Sprite;

    [SerializeField]
    GameObject dave_Sushi_Give;

    [SerializeField]
    GameObject cook_Perfab;


    GameObject dave_collision;


    bool spacePressed = false;

    void Start()
    {
        
    }

    private void OnDisable()
    {
        spacePressed = false;

        childindex = 0;
        banCho.SetBool("Work", false);
    }


    private void OnCollisionEnter2D(Collision2D _collision)
    {
       
        spacePressed = true;
        dave_collision = _collision.gameObject;
    
    }

    private void OnCollisionExit2D(Collision2D _collision)
    {
        spacePressed = false;
        dave_collision = null;
    }

    void ServeSushiToDave()
    {    
        if (Input.GetKeyDown(KeyCode.Space) && transform.childCount >= 1 && dave_collision != null && spacePressed == true)
        {
            AnimatorStateInfo stateInfo = dave_collision.GetComponent<Sushi_Dave>().Get_animatior().GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("Sushi_Dave_Idle") && transform.GetChild(0).GetComponent<Cook>().Get_fillGauge().fillAmount >= 1)
            {
                dave_collision.GetComponent<Sushi_Dave>().Get_animatior().SetTrigger("Change_Serve");
                dave_Sushi_Give.SetActive(true);
                dave_collision.GetComponent<Sushi_Dave>().Set_Sushi_Path(transform.GetChild(0).GetComponent<Cook>().Get_sushiPath());
                dave_Sushi_Sprite.sprite = Resources.Load<Sprite>(transform.GetChild(0).GetComponent<Cook>().Get_sushiPath());
                childindex--;
                DestroyImmediate(transform.GetChild(0).gameObject);
                spacePressed = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && spacePressed == false)
        {
            spacePressed = true;
        }

    }

    public void Cook_Choice(int menu_Count_Check,List<Menu> menus,int menuindex)
    {
       
        if (menu_Count_Check == menus.Count)
        {
            cook_Perfab.GetComponent<Cook>().Make_Prefap(transform, "Sushi/Sushi_Gim");
        }
        else
        {
            cook_Perfab.GetComponent<Cook>().Make_Prefap(transform, menus[menuindex].Get_sushi_path());
        }
   
    }


    void Sushi_Make()
    {
        if (childindex == transform.childCount)
        {
            Audio_Manager.GetInstance().Sfx_Stop(Audio_Manager.sfx.effect_chopping_board);
            audio_Check = false;
            banCho.SetBool("Work", false);
            return;
        }

        if (audio_Check == false)
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.effect_chopping_board, true);
            audio_Check = true;
        }

        banCho.SetBool("Work", true);

        if (transform.childCount > 0)
        {
            transform.GetChild(childindex).GetComponent<Cook>().cook_FillAmount();
        }



        if (transform.GetChild(childindex).GetComponent<Cook>().Get_fillGauge().fillAmount >= 1)
        {

            int random = Random.Range(0, 2);

            if (random == 0)
            {
                Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.sushi_bancho_foodready, false);
            }
            else
            {
                Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.sushi_bancho_foodready_02, false);
            }

            childindex++;
        }
    }

    void Update()
    {
        ServeSushiToDave();
        Sushi_Make();
    }
}
