using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Start : MonoBehaviour
{
    [SerializeField]
    GameObject alpha;
    // Start is called before the first frame update
    void Start()
    {
        Audio_Manager.GetInstance().PlayBgm(Audio_Manager.bgm.Title);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            alpha.SetActive(true);
        }
    }
}
