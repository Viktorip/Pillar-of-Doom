using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject maincam;

    private float angle = 0;
    private float speed = 1f;
    private float radius = 0.6f;

    private float offset = 3f;
    private float yoffset = 0.3f;

    private Rigidbody rigidb;

    private Vector3 newpos;
    private Vector3 oldpos;

    // Start is called before the first frame update
    void Start()
    {
        angle += Time.deltaTime * speed;
        oldpos = new Vector3(Mathf.Sin(angle) * radius, transform.position.y, Mathf.Cos(angle) * radius);
        transform.position = oldpos;
        rigidb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }else if(Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        
        
    }

    private void MoveLeft()
    {
        angle += Time.deltaTime * speed;
        movefunc();
    }

    private void MoveRight()
    {
        angle -= Time.deltaTime * speed;
        movefunc();
    }

    private void movefunc()
    {
        //rigidb.MovePosition(new Vector3(Mathf.Sin(angle) * radius, transform.position.y, Mathf.Cos(angle) * radius));
        
        newpos = new Vector3(Mathf.Sin(angle) * radius, transform.position.y, Mathf.Cos(angle) * radius);
        transform.position -= (oldpos - newpos);
        maincam.transform.position = new Vector3(transform.position.x * offset, transform.position.y + yoffset, transform.position.z * offset);
        oldpos = newpos;
        
    }

    void OnTriggerEnter(Collider other)
    {
        print("trigger");
    }
}
