using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rig;

    Vector2 vel;

    public Transform floorCollider;

    public Transform skin;

    public int numeroCombo;
    public float tempoCombo;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        tempoCombo = tempoCombo + Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && tempoCombo > 0.5f)
        {
            numeroCombo++;

            if (numeroCombo > 2)
            {
                numeroCombo = 1;
            }

            tempoCombo = 0;
            skin.GetComponent<Animator>().Play("PlayerAtack" + numeroCombo, -1);
        }

        if (tempoCombo >=  1)
        {
            numeroCombo = 0;
        }


        if (Input.GetButtonDown("Jump") && floorCollider.GetComponent<FloorCollider>().canJump == true)
        {
            skin.GetComponent<Animator>().Play("PlayerJump", -1);
            rig.velocity = Vector2.zero;
            floorCollider.GetComponent<FloorCollider>().canJump = false;
            rig.AddForce(new Vector2(0, 150));
        }
        vel = new Vector2(Input.GetAxisRaw("Horizontal"), rig.velocity.y);



        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            skin.GetComponent<Animator>().SetBool("playerRun", true);
        }
        else
        {
            skin.GetComponent<Animator>().SetBool("playerRun", false);
        }

    }

    void FixedUpdate()
    {
        rig.velocity = vel;
    }
}
