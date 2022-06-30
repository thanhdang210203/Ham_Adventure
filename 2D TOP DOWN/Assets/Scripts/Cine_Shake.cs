using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Cine_Shake : MonoBehaviour
{
    public static Cine_Shake Instance { get; private set; }
    private CinemachineVirtualCamera cinemachine;
    private float shakeTimer;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        cinemachine = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
        cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
    void Update()
    {
     if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                //Time over
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }   
    }
}
