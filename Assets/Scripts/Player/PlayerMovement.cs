using System;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (CapsuleCollider))]
public class PlayerMovement : MonoBehaviour
{
    [Serializable]
    public class MovementSettings
    {
        public float ForwardSpeed = 8.0f;   // Speed when walking forward
        public float BackwardSpeed = 4.0f;  // Speed when walking backwards
        public float StrafeSpeed = 4.0f;    // Speed when walking sideways
        public float RunMultiplier = 2.0f;   // Speed when sprinting
        public KeyCode RunKey = KeyCode.LeftShift;
        public float JumpForce = 30f;
        public float rotationSpeed = 20f;
    }
    
    public Camera cam;
    public MovementSettings movementSettings = new MovementSettings();
    //public MouseLook mouseLook = new MouseLook();
    //public AdvancedSettings advancedSettings = new AdvancedSettings();

    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private Vector2 lastMousePosition;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        RotateView();

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * movementSettings.ForwardSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * movementSettings.BackwardSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * movementSettings.StrafeSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * movementSettings.StrafeSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    void RotateView()
    {
        rb.angularVelocity = Vector3.zero;

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 rotationAmount = mousePosition - lastMousePosition;

        Vector3 capsuleRotate = new Vector3(0.0f, rotationAmount.x * movementSettings.rotationSpeed * Time.deltaTime, 0.0f);
        transform.Rotate(capsuleRotate);

        lastMousePosition = mousePosition;
    }
}
