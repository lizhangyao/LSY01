using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerTransform;
    public Vector3 offset = new Vector3();
    void Start()
    {
        
    }
    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
