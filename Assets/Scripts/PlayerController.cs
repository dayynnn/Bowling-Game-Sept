using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float throwStrength;
    [SerializeField] private Rigidbody myRigidBody;
    [SerializeField] private bool wasThrown;
    [SerializeField] private GameObject aimingArrow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
        ThrowingBall();
    }

    void MoveBall()
    {
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        if (!wasThrown)
        {
            transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0, 0);
        }
        
    }
    void ThrowingBall()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !wasThrown)
        {
            //gameObject.SetActive(false);

            aimingArrow.SetActive(false);

            wasThrown = true;
            myRigidBody.AddForce(aimingArrow.transform.forward * throwStrength, ForceMode.Impulse); //myRigidBody.AddForce(Vector3.forward * throwStrength, ForceMode.Impulse);
            Invoke("StopThrow", 8f);
        }
    } 

    void OnTriggerEnter(Collider other) // has Stay and Exit  methods too.
    {
        StopThrow();
        
    }

    void StopThrow()
    {
        FindObjectOfType<GameManager>().BallInPit();
        Destroy(gameObject, 2);
    }
 
}

