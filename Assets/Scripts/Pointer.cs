using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;

    private Vector3 startpos1;
    private Vector3 startpos2;
    void Start()
    {
        startpos1 = transform.position;
        startpos2 = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
    }
    
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, startpos1, Time.fixedDeltaTime * speed);
        if (transform.position == startpos1)
        {
            startpos1 = startpos2;
            if (startpos1 == startpos2)
            {
                startpos2 = transform.position;
            }
        }
    }
}