using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dash_Gauage : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update


    public float GetGuage()
    {
        return image.fillAmount;
    }



    void Start()
    {
        image = GetComponent<Image>();
    }

    public void gauageDown()
    {
        image.fillAmount -= Time.deltaTime * 0.1f;
    }

    public void GauageUp()
    {
        image.fillAmount += Time.deltaTime;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
