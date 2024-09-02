using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class O2_Check : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;


    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();  
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount -= Time.deltaTime * 0.003f;

        int O2font = (int)(image.fillAmount * 100);

        textMeshProUGUI.text = O2font.ToString();
            
    }

    private void OnDisable()
    {
        image.fillAmount = 1;
        textMeshProUGUI.text = 100.ToString();
    }

}
