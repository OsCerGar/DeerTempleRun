
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    public float moveSpeed;
    public GameObject mainCamera, player;
    public bool jumping, touchingGround;
    float jump, step;
    public Vector3[] positions = new Vector3[3];

    // Use this for initialization
    void Start()
    {
        mainCamera.transform.localPosition = new Vector3(0, 0, 0);
        mainCamera.transform.localRotation = Quaternion.Euler(18, 0, 0);
        player = this.transform.GetChild(0).gameObject;
        player.transform.localPosition = new Vector3(0, -4.5f, 7);

        positions[0].x = -1;
        positions[1].x = 0;
        positions[2].x = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (moveSpeed < 10)
        {
            moveSpeed += Time.deltaTime * 0.5f;

        }

        if (player.transform.localPosition.y == -4.5f)
        {
            touchingGround = true;
        }
        else {
            touchingGround = false;

        }

        PlayerMovement();


        /*Jumping*/
        if (jumping == true)
        {
            step += 1.5f * Time.deltaTime;

            player.transform.localPosition = Vector3.MoveTowards(player.transform.localPosition, new Vector3(player.transform.localPosition.x, jump, player.transform.localPosition.z), step);

            if (step > 1)
            {
                jumping = false;
                step = 0;
            }
        }
        else
        {
            float step = 2 * Time.deltaTime;
            player.transform.localPosition = Vector3.MoveTowards(player.transform.localPosition, new Vector3(player.transform.localPosition.x, -4.5f, player.transform.localPosition.z), step);
        }


    }

    private void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (player.transform.position.x == positions[0].x && jumping == false)
            {
                Debug.Log("Cannot go LEFT");
            }
            else
            {
                if (player.transform.position.x == positions[1].x && jumping == false)
                {
                    //player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(positions[0].x, player.transform.position.y, player.transform.position.z), 1f);
                    player.transform.position = new Vector3(positions[0].x, player.transform.position.y, player.transform.position.z);
                }

                if (player.transform.position.x == positions[2].x && jumping == false)
                {
                    //player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(positions[1].x, player.transform.position.y, player.transform.position.z), 1f);
                    player.transform.position = new Vector3(positions[1].x, player.transform.position.y, player.transform.position.z);

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (player.transform.position.x == positions[2].x && jumping == false)
            {
                Debug.Log("Cannot go Right");
            }
            else
            {
                if (player.transform.position.x == positions[1].x && jumping == false)
                {
                    //player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(positions[2].x, player.transform.position.y, player.transform.position.z), 1f);
                    player.transform.position = new Vector3(positions[2].x, player.transform.position.y, player.transform.position.z);
                }
                if (player.transform.position.x == positions[0].x && jumping == false)
                {
                    //player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(positions[1].x, player.transform.position.y, player.transform.position.z), 1f);
                    player.transform.position = new Vector3(positions[1].x, player.transform.position.y, player.transform.position.z);

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && touchingGround == true)
        {
            jumping = true;
            jump = player.transform.localPosition.y + 2;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeView01();
        }

    }

    void FixedUpdate()
    {
        MoveObj();

    }


    void MoveObj()
    {
        float moveAmount = Time.smoothDeltaTime * moveSpeed;
        transform.Translate(0f, 0f, moveAmount);
    }



    void ChangeView01()
    {
        //transform.position = new Vector3 (0, 2, 10);
        // x:0, y:1, z:52
        mainCamera.transform.localPosition = new Vector3(-8, -2, 8);
        mainCamera.transform.localRotation = Quaternion.Euler(14, 90, 0);
    }

}























