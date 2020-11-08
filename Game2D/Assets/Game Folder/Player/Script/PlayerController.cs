using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rig;

    Vector2 vel;

    public Transform floorCollider;

    public Transform skin;

    public int comboNum;
    public float comboTime;
    public float dashTime;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        dashTime = dashTime + Time.deltaTime;
        if (Input.GetButtonDown("Fire2") && dashTime > 1)
        {
            dashTime = 0;
            skin.GetComponent<Animator>().Play("PlayerDash", -1);
            rig.velocity = Vector2.zero;
            rig.AddForce(new Vector2(skin.localScale.x * 150, 0));
        }

        if (GetComponent<Character>().life <= 0)
        {
            this.enabled = false;
        }
        comboTime = comboTime + Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && comboTime > 0.5f)
        {
            comboNum++;

            if (comboNum > 2)
            {
                comboNum = 1;
            }

            comboTime = 0;
            skin.GetComponent<Animator>().Play("PlayerAtack" + comboNum, -1);
        }

        if (comboTime >= 1)
        {
            comboNum = 0;
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
        if (dashTime > 0.5)
        {
            rig.velocity = vel;
        }

    }
}
