using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float LightDecay = 0.1f;
    [SerializeField] float AngleDecay = 1f;
    Light MyLight;
    void Start()
    {
        MyLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        MyLight.intensity -= LightDecay*Time.deltaTime;
        if(MyLight.spotAngle > 40)
        {
            MyLight.spotAngle -= AngleDecay*Time.deltaTime;
        }
    }

    public void RestoreLight()
    {
        MyLight.intensity = 10f;
        MyLight.spotAngle = 70f;
    }
}
