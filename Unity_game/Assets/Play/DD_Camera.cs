using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class ScreenShake
{
    public float duration; // 흔들림이 지속되는 시간
    public float magnitude; // 흔들림의 세기
    public float elapsed; // 흔들림이 지속되는 시간 타이머
    public float frequency = 2.0f; // 흔들림의 빈도
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
            // 보다 자연스러운 감쇠를 위해 부드러운 단계 함수를 사용하여 시간이 지남에 따라 흔들림 계수가 1에서 0으로 감소합니다.
            float swayFactor = 1.0f - (Mathf.Pow(screenShakeValue.elapsed / screenShakeValue.duration, 2));

            // 부드러운 진동을 위해 사인파를 사용하여 스웨이 오프셋을 계산합니다.
            // 주파수는 초당 발생하는 전체 진동 횟수를 결정합니다.
            float phase = screenShakeValue.elapsed * screenShakeValue.frequency * Mathf.PI * 2.0f;

            UnityEngine.Random.Range(0, 1000 * 0.001f * Mathf.PI * 2.0f);

            // 각 축에 대해 사인파의 위상과 진폭을 무작위화합니다.
            float randomPhaseX = UnityEngine.Random.Range(0, 1000 * 0.001f * Mathf.PI * 2.0f); // 0과 2*PI 사이의 랜덤 위상
            float randomPhaseY = UnityEngine.Random.Range(0, 1000 * 0.001f * Mathf.PI * 2.0f);

            float randomAmplitudeX = UnityEngine.Random.Range(0, 1000 * 0.001f * screenShakeValue.magnitude);
            float randomAmplitudeY = UnityEngine.Random.Range(0, 1000 * 0.001f * screenShakeValue.magnitude);


            // 부드러운 진동을 위해 무작위성을 가진 사인파를 사용하여 흔들림 오프셋을 계산합니다.
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
