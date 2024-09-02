using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class ScreenShake
{
    public float duration; // ��鸲�� ���ӵǴ� �ð�
    public float magnitude; // ��鸲�� ����
    public float elapsed; // ��鸲�� ���ӵǴ� �ð� Ÿ�̸�
    public float frequency = 2.0f; // ��鸲�� ��
};

public class DD_Camera : MonoBehaviour
{

    Vector3 PrevShackeMovePos = Vector3.zero;
    Vector3 PrevShackeRotationPos = Vector3.zero;

    ScreenShake screenShakeValue = new ScreenShake();
    CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnDisable()
    {
        virtualCamera.Follow = null;
        virtualCamera.transform.position = new Vector3(-12.21837f, 12.93999f, -10);
    }

    public void StartScreenShake(float duration = 0.5f, float magnitude = 0.06f, float frequency = 1.0f)
    {
        screenShakeValue.duration = duration;
        screenShakeValue.magnitude = magnitude;
        screenShakeValue.frequency = frequency;
        screenShakeValue.elapsed = 0.0f;
    }

    void UpdateScreenShake(float _deltaTime)
    {
        if (screenShakeValue.elapsed < screenShakeValue.duration)
        {
            // ���� �ڿ������� ���踦 ���� �ε巯�� �ܰ� �Լ��� ����Ͽ� �ð��� ������ ���� ��鸲 ����� 1���� 0���� �����մϴ�.
            float swayFactor = 1.0f - (Mathf.Pow(screenShakeValue.elapsed / screenShakeValue.duration, 2));

            // �ε巯�� ������ ���� �����ĸ� ����Ͽ� ������ �������� ����մϴ�.
            // ���ļ��� �ʴ� �߻��ϴ� ��ü ���� Ƚ���� �����մϴ�.
            float phase = screenShakeValue.elapsed * screenShakeValue.frequency * Mathf.PI * 2.0f;

            UnityEngine.Random.Range(0, 1000 * 0.001f * Mathf.PI * 2.0f);

            // �� �࿡ ���� �������� ����� ������ ������ȭ�մϴ�.
            float randomPhaseX = UnityEngine.Random.Range(0, 1000 * 0.001f * Mathf.PI * 2.0f); // 0�� 2*PI ������ ���� ����
            float randomPhaseY = UnityEngine.Random.Range(0, 1000 * 0.001f * Mathf.PI * 2.0f);

            float randomAmplitudeX = UnityEngine.Random.Range(0, 1000 * 0.001f * screenShakeValue.magnitude);
            float randomAmplitudeY = UnityEngine.Random.Range(0, 1000 * 0.001f * screenShakeValue.magnitude);


            // �ε巯�� ������ ���� ���������� ���� �����ĸ� ����Ͽ� ��鸲 �������� ����մϴ�.
            //float time = screenShakeValue.elapsed * screenShakeValue.frequency;
            float offsetX = Mathf.Sin(phase + randomPhaseX) * randomAmplitudeX * swayFactor;
            float offsetY = Mathf.Cos(phase + randomPhaseY) * randomAmplitudeY * swayFactor;

            //float offsetZ = ContentsCore::MainRandom->RandomFloat(-2.0f, 2.0f);

            transform.Translate(-PrevShackeMovePos + new Vector3(offsetX, offsetY, 0.0f));

            transform.Translate(-PrevShackeMovePos + new Vector3(offsetX, offsetY, 0.0f));

            PrevShackeMovePos = new Vector3(offsetX, offsetY, 0.0f);

            //GetMainCamera()->Transform.AddLocalRotation(-PrevShackeRotationPos + float4(0.0f, 0.0f, offsetZ,0.0f));
            //PrevShackeRotationPos = float4(0.0f, 0.0f, offsetZ, 0.0f);


            screenShakeValue.elapsed += _deltaTime;
        }
        else if (PrevShackeMovePos != Vector3.zero)
        {
            transform.Translate(-PrevShackeMovePos);
            //GetMainCamera()->Transform.AddLocalRotation(-PrevShackeRotationPos);
            PrevShackeMovePos = Vector3.zero;
            //PrevShackeRotationPos = float4::ZERO;
        }
    }

    public void CameraMove(bool _Check_X, bool _Check_Y,float _speed, FsmClass<pSCENE_STATE> _fsm)
    {
        if(_Check_X == true && _Check_Y == true)
        {
            return;
        }

        if (_Check_X == false && _Check_Y == false)
        {
            
        }




        if (_fsm.getStateType == pSCENE_STATE.Left_Side_Up_Move && _Check_X == true && _Check_Y ==false)
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
        if(_fsm.getStateType == pSCENE_STATE.Left_Side_Up_Move && _Check_X == false && _Check_Y == true)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if (_fsm.getStateType == pSCENE_STATE.Left_Side_Down_Move && _Check_X == true && _Check_Y == false)
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }

        if (_fsm.getStateType == pSCENE_STATE.Left_Side_Down_Move && _Check_X == false && _Check_Y == true)
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }



        if (_fsm.getStateType == pSCENE_STATE.Left_Side_Down_Move)
        {

        }
        if (_fsm.getStateType == pSCENE_STATE.Right_Side_Up_Move)
        {

        }
        if (_fsm.getStateType == pSCENE_STATE.Right_Side_Down_Move)
        {
           
        }



        if (_fsm.getStateType == pSCENE_STATE.Left_Move && _Check_X == true)
        {
            
        }
        if (_fsm.getStateType == pSCENE_STATE.Right_Move && _Check_X == true)
        {
           
        }

        if (_fsm.getStateType == pSCENE_STATE.Up_Move && _Check_Y == true)
        {

        }

        if (_fsm.getStateType == pSCENE_STATE.Down_Move && _Check_Y == true)
        {

        }




    }
    // Update is called once per frame



    void Update()
    {
        UpdateScreenShake(Time.deltaTime);
    }


}
