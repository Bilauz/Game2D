using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rig;

    Vector2 vel;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        vel = new Vector2(Input.GetAxisRaw("Horizontal"), rig.velocity.y);


    }

    void FixedUpdate()
    {
        rig.velocity = vel;
    }
}
