using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidBody;
    private Quaternion originalRot;
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalRot = transform.rotation;
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPinFallen())
        {
            Debug.Log("Pin Fell");
        }   
    }
    public bool IsPinFallen()
    {
        //calculation of fallen pins
        if(transform.rotation.x > 0.1f || transform.rotation.x < -0.1f || transform.rotation.z > 0.1f || transform.rotation.z < -0.1f)
        {
            return true;
        }
        return false;
    }

   public void ResetPinToOrigin()
    {
        myRigidBody.velocity = Vector3.zero;
        myRigidBody.angularVelocity = Vector3.zero;
        transform.rotation = originalRot;
        transform.position = originalPos;

    }

}
