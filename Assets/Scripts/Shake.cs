using UnityEngine;
using Cinemachine;

public class Shake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float startingIntensity;
    private float shakeTimerTotal;
    private float shakeTimer;

    private void Awake() => cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        startingIntensity = intensity;

        shakeTimerTotal = time;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 
                Mathf.Lerp(startingIntensity, 0f, (1 - shakeTimer / shakeTimerTotal));
        }
    }
}
