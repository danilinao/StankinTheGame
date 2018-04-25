using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController charControl;
    public float walkSpeed;
    public float runSpeed;
    public bool cameraShake;

    private float speed;

    void Awake()
    {
        speed = 0;
        charControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }


        Vector3 moveDirSide = transform.right * horiz * speed;
        Vector3 moveDirForward = transform.forward * vert * speed;

        charControl.SimpleMove(moveDirSide);
        charControl.SimpleMove(moveDirForward);
        if(cameraShake && (horiz != 0 || vert != 0))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetComponentInChildren<Animator>().SetFloat("speed", 1.3f);
            }
            else
            {
                GetComponentInChildren<Animator>().SetFloat("speed", 1f);
            }
        }
        else
        {
            GetComponentInChildren<Animator>().SetFloat("speed", 0f);
        }

    }
}
