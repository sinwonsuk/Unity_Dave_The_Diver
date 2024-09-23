using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cook : MonoBehaviour
{
    [SerializeField]
    Image fillGauge;

    [SerializeField]
    Image sushi_Sprite;

    string sushiPath;

    public string Get_sushiPath()
    {
        return sushiPath;
    }


    public Image Get_fillGauge()
    {
        return fillGauge;
    }


    Image cooking_Box;

    float speed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        cooking_Box = GetComponent<Image>();
    }

    public void Make_Prefap(Transform _cook_Transform_Parent, string path)
    {       
        GameObject instance = Instantiate(gameObject, _cook_Transform_Parent);

        instance.GetComponent<Cook>().sushiPath = path;

        instance.GetComponent<Cook>().sushi_Sprite.sprite = Resources.Load<Sprite>(path);
    }

    public void cook_FillAmount()
    {
        
            fillGauge.fillAmount += Time.deltaTime * speed;

            if (fillGauge.fillAmount >= 1)
            {
                cooking_Box.sprite = Resources.Load<Sprite>("Cooking/UI_Sushi_Cooking_Box_Complete");              
            }        
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      

    }
}
