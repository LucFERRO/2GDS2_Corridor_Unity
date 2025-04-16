using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 6.0f;
    //public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    public bool ballarina;
    public int rotateSpeed = 5;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        BallarinaHandle();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballarina = !ballarina;
        }

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            //if (Input.GetButton("Jump"))
            //    moveDirection.y = jumpSpeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void BallarinaHandle()
    {
        if (!ballarina)
        {
            return;
        }
        transform.eulerAngles += new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + rotateSpeed, transform.eulerAngles.z);
    }
}