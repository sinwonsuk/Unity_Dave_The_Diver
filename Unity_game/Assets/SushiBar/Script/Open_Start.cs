using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Image yellow;

    [SerializeField]
    GameObject open;

    [SerializeField]
    GameObject time;

    public float speed;


    void Start()
    {
       
    }

    private void OnDisable()
    {
        yellow.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_lobby_dive, true);
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            Audio_Manager.GetInstance().Sfx_Stop(Audio_Manager.sfx.ui_lobby_dive);
        }

        if(Input.GetKey(KeyCode.F))
        {       
            yellow.fillAmount += speed * Time.deltaTime *0.5f;
        }
        else
        {
            yellow.fillAmount -= speed * Time.deltaTime * 0.5f;
        }
        
        if(yellow.fillAmount >=1)
        {
            Audio_Manager.GetInstance().Sfx_Stop(Audio_Manager.sfx.ui_lobby_dive);
            Audio_Manager.GetInstance().SfxPlay(Audio_Manager.sfx.ui_sushibar_open,false);
            gameObject.SetActive(false);


            open.SetActive(true);
            time.SetActive(true);
        }


    }
}
