using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrounds : MonoBehaviour
{
    // Start is called before the first frame update
     public Transform[] backGrounds;
    public float fparallax = 0.4f;//总体的移动
    public float layerFraaction = 5f;//每层的移动量
    public float fSmooth = 5f;//平滑度
    Transform cam;
    Vector3 previousCamPos;


    private void Awake()
    {
        cam = Camera.main.transform;//cmera这个类里面的main

    }
    private void Start() 
    {
        previousCamPos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        float fParrlaxX = (previousCamPos.x - cam.position.x) * fparallax;
        for(int i = 0; i < backGrounds.Length; i++)
        {
            float fNewX = backGrounds[i].position.x + fParrlaxX * (1 + i * layerFraaction);
            Vector3 newPos = new Vector3(fNewX, backGrounds[i].position.y, backGrounds[i].position.z);
            backGrounds[i].position = Vector3.Lerp(backGrounds[i].position,newPos,Time.deltaTime);
        }
        previousCamPos = cam.position;

    }
}
