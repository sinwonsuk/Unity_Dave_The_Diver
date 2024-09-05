using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dave_Attack_Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    bool Stop_Check = false;
    Vector3 prevMousePos = new Vector3();
    float rotateSpeed = 200.0f;

    public void Set_Stop(bool _Check)
    {
        Stop_Check = _Check;
    }

    void Update()
    {
            if(Stop_Check==true)
            {
                return;
            }



            Quaternion currentRotation = transform.localRotation;

        
            Vector3 currentEulerAngles = currentRotation.eulerAngles;


 
            if(currentEulerAngles.z > 300 && currentEulerAngles.z <360)
            {
                currentEulerAngles.z -= 360;
            }
       

            if (prevMousePos.y < Input.mousePosition.y && currentEulerAngles.z < 40.0f)
            {

                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            }

       

            if (prevMousePos.y > Input.mousePosition.y && currentEulerAngles.z > -40.0f)
            {

                transform.Rotate(-Vector3.forward * rotateSpeed * Time.deltaTime);
            }
            if (prevMousePos.y == Input.mousePosition.y)
            {
                return;
            }
        

            prevMousePos = Input.mousePosition;
    }
}
