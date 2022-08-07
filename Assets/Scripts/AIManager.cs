using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static AIManager aimanagerInstance;
    Rigidbody rb;
    private Vector3 startPosition;
    public bool isMove;
    public bool isFinish;


    private void Awake()
    {
        if (aimanagerInstance == null)
        {
            aimanagerInstance = this;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = this.transform.position;
        isMove = false;
        isFinish = false;
    }

    
    void Update()
    {
        
    }
    IEnumerator RestartPosition()
    {
        yield return new WaitForSeconds(1f);
        this.transform.position = this.startPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            // E�er karakter Finish cizgisini gecmisse karakter hareket etmez
            this.GetComponent<AvoidingObstacles>().StartCoroutine("EnemyStop");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("StaticObstacle"))
        {
            // Eger StaticObstacle objesine temas etmisse tekrar oyna
            StartCoroutine(nameof(RestartPosition));
        }
        if (collision.gameObject.CompareTag("HorizontalObstacle"))
        {
            // Eger HorizontalObstacle objesine temas etmisse tekrar oyna
            StartCoroutine(nameof(RestartPosition));
        }
        if (collision.gameObject.CompareTag("MovingStick"))
        {
            // Eger MovingStick objesine temas etmisse tekrar oyna
            StartCoroutine(nameof(RestartPosition));
        }
        if (collision.gameObject.CompareTag("RotatingStick"))
        {
            // Eger RotatingStick objesine temas etmisse cubuk kuvvet uygular
            rb.AddForce(collision.gameObject.transform.right * 300f * Time.fixedDeltaTime, ForceMode.Impulse);
            StartCoroutine(nameof(RestartPosition));
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        //if (collision.gameObject.CompareTag("RotatingPlatform"))
        //{
        //    // RotatingPlatform objesine temas etmisse
        //    isRotatingPlatform = true;
        //    isRight = collision.gameObject.GetComponent<RotatingPlatform>().turnDirection;
        //}
    }
    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.CompareTag("RotatingPlatform"))
        //{
        //    // RotatingPlatform objesinden ��km��sa
        //    isRotatingPlatform = false;
        //}
    }
}