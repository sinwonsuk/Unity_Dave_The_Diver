using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sushi_Dave : MonoBehaviour
{
    public FsmClass<Sushi_SCENE_STATE> fsm = new FsmClass<Sushi_SCENE_STATE>();

    [SerializeField]
    Animator animatior;



    Vector2 start_Transform;

    [SerializeField]
    Dash_Gauage dash_Gauage;
    [SerializeField]
    GameObject sushi_Give;



    string Sushi_Path;

    public Animator Get_animatior()
    {
        return animatior;
    }

    public string Get_Sushi_Path()
    {
        return Sushi_Path;  
    }
    public void Set_Sushi_Path(string _path)
    {
        Sushi_Path = _path;
    }

    private void OnDisable()
    {

        sushi_Give.SetActive(false);    
        dash_Gauage.GetComponent<Image>().fillAmount = 1;
        gameObject.GetComponent<RectTransform>().anchoredPosition = start_Transform;
        fsm.SetState(Sushi_SCENE_STATE.Idle);
    }

    private void OnEnable()
    {
        Audio_Manager.GetInstance().PlayBgm(Audio_Manager.bgm.SushiBar);
        start_Transform = gameObject.GetComponent<RectTransform>().anchoredPosition;
    }



    // Start is called before the first frame update
    void Start()
    {
       Init();
       fsm.SetState(Sushi_SCENE_STATE.Idle);
    }
    public void Init()
    {
        fsm.AddFsm(new Sushi_Dave_Idle(this, animatior,gameObject,dash_Gauage));
        fsm.AddFsm(new Sushi_Dave_Move(this, animatior, gameObject, dash_Gauage));
        fsm.AddFsm(new Sushi_Dave_Run(this, animatior, gameObject, dash_Gauage));
        fsm.AddFsm(new Sushi_Dave_Tired_Move(this, animatior, gameObject));
    }
        // Update is called once per frame
        void Update()
    {


        fsm.Update();
    }
}
