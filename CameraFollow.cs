﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//对象的首字母小写，类的首字母大写
public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float maxDistanceX = 1;
    public float maxDistanceY = 1;
    public float xSpeed = 2;
    public float ySpeed = 2;

    public Vector2 maxXandY = new Vector2(2,1);
    public Vector2 minXandY = new Vector2(-2, 0);

    private void Awake()
    {
        // playerTransform = GameObject.Find("hero").transform;   //找到场景的游戏对象
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        TrackPlayer();
    }

    private bool NeedMoveX()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x - playerTransform.position.x) > maxDistanceX)
            bMove = true;
        else
            bMove = false;
        return bMove;
    }

    private bool NeedMoveY()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.y - playerTransform.position.y) > maxDistanceY)
            bMove = true;
        else
            bMove = false;

        return bMove;
    }

    private void TrackPlayer()
    {
        float newCameraX = transform.position.x;
        float newCameraY = transform.position.y;

        if (NeedMoveX())
            newCameraX = Mathf.Lerp(transform.position.x, playerTransform.position.x, xSpeed * Time.deltaTime);

        if (NeedMoveY())
            newCameraY = Mathf.Lerp(transform.position.y, playerTransform.position.y, ySpeed * Time.deltaTime);
        // float Lerp(float a,float b,float t) 返回值为 a+(b-a)*t,  t小于1

        newCameraX = Mathf.Clamp(newCameraX, minXandY.x, maxXandY.x);
        newCameraY = Mathf.Clamp(newCameraY, minXandY.y, maxXandY.y);
        //float Clamp(float value,float min,float max) 返回值为 min 和 max 之间的数

        transform.position = new Vector3(newCameraX, newCameraY, transform.position.z);

    }
}