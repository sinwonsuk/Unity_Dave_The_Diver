using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class depth_UI : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;

    [SerializeField]
    Transform player_transform;

    Vector3 prevePos;

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vector3 = player_transform.position;
      
        vector3.y = vector3.y - 25.7f;
        vector3.y *= -1;


        if(vector3.y < 0)
        {
            textMeshProUGUI.text = "0.0m";
        }
        else
        {
            textMeshProUGUI.text = vector3.y.ToString("0.0") + "m";
        }
       




      
    }
}
