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
    float time = 0;

    bool left_camera_check = false;
    bool right_camera_check = false;

    Vector3 PrevShackeMovePos = Vector3.zero;
    Vector3 PrevShackeRotationPos = Vector3.zero;

    ScreenShake screenShakeValue = new ScreenShake();
    CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin noise;
    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
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

         

            transform.Translate(-PrevShackeMovePos + new Vector3(offsetX, offsetY, 0.0f));

            transform.Translate(-PrevShackeMovePos + new Vector3(offsetX, offsetY, 0.0f));

            PrevShackeMovePos = new Vector3(offsetX, offsetY, 0.0f);

          


            screenShakeValue.elapsed += _deltaTime;
        }
        else if (PrevShackeMovePos != Vector3.zero)
        {
            transform.Translate(-PrevShackeMovePos);
          
            PrevShackeMovePos = Vector3.zero;
          
        }
    }

    public void CameraShake_Start()
    {       
        noise.m_AmplitudeGain = 5f;
        noise.m_FrequencyGain = 80f;    
    }

    public void CameraShake_Stop()
    {              
        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;      
    }

    public void CameraMove(FsmClass<pSCENE_STATE> _fsm, Transform _daveTransform)
    {
        if (_fsm.Getstate.stateType != pSCENE_STATE.Start)
        {
            if (_daveTransform.localPosition.x <= -17.0f)
            {
                Vector3 vector3 = _daveTransform.position;

                vector3.x = virtualCamera.transform.position.x;
                vector3.y = _daveTransform.position.y;
                vector3.z = -10.0f;
                virtualCamera.Follow = null;
                virtualCamera.transform.position = vector3;
                left_camera_check = true;
            }

            else if (_daveTransform.localPosition.x > -17.0f && left_camera_check == true)
            {
                Vector3 vector3 = _daveTransform.position;
                vector3.z = -10.0f;

                virtualCamera.transform.position = vector3;
                virtualCamera.Follow = _daveTransform;
                left_camera_check = false;
            }

            if (_daveTransform.localPosition.x >= 52)
            {
                Vector3 vector3 = _daveTransform.position;

                vector3.x = virtualCamera.transform.position.x;
                vector3.y = _daveTransform.position.y;
                vector3.z = -10.0f;
                virtualCamera.Follow = null;
                virtualCamera.transform.position = vector3;
                right_camera_check = true;
            }

            else if (_daveTransform.localPosition.x < 52 && right_camera_check == true)
            {
                virtualCamera.Follow = _daveTransform;
                right_camera_check = false;
            }
        }
    }
}
