using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Rigidbody rigidbody;
    float speed = 5f;
    public Animator door;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hVal = Input.GetAxis("Horizontal");
        float vVal = Input.GetAxis("Vertical");
        Vector3 mInput = new Vector3(hVal, 0, vVal);

        if (vVal != 0 || hVal != 0)
        {
            rigidbody.MovePosition(transform.position + mInput * Time.deltaTime * speed);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!door.GetBool("Door_Anim"))
            {
                door.SetBool("Door_Anim", true);
            }
            else
            {
                door.SetBool("Door_Anim", false);
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        door.SetBool("Door_Anim", true);
    }

    private void OnTriggerExit(Collider other)
    {
        door.SetBool("Door_Anim", false);
    }
}
