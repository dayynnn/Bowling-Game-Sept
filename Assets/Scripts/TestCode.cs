using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public Vector3 movingDirection;


    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(0.1f,0.1f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movingDirection.x = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movingDirection.x = -1;
        }

        transform.Translate(movingDirection * Time.deltaTime);
        movingDirection.x = 0;
        if(Input.GetMouseButton(0))
        {
            transform.Translate(0.1f * Time.deltaTime, 0, 0);
        }
        
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(0, 0, 180 * Time.deltaTime);
        }

        if (Time.realtimeSinceStartupAsDouble > 15 && 3 > 0)
        {
            transform.Rotate(0, 0, 180 * Time.deltaTime);
            
        }

        //transform.Translate(0, 0, 0);
      
        //Debug.Log(transform.position);
    }
}
