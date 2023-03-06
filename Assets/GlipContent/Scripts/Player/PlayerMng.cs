using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMng : MonoBehaviour
{

    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private float moveSpeed = 10f;

    private Rigidbody rb;
    private float timeSinceStart = 0f;

    public float[] Xdir;

    public Vector3 MoveDir;

    public Vector3 stateDir;

    public static PlayerMng ins;

    public Animator anim;

    public float jumpHeight = 2.0f;
    public float jumpTime = 1.0f;

    private bool isJumping = false;
    private float jumpTimer = 0.0f;
    public Vector3 jumpvecor;
    public float jumpfactor;

    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private int directionState = 1;
    float DirChangeTimer = 0;
    Vector3 targetRot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            MoveRight();

        if (Input.GetKeyDown(KeyCode.A))
            MoveLeft();


        if (Input.GetKeyDown(KeyCode.Space) && CheckGrounded())
        {
            isJumping = true;
            jumpTimer = 0.0f;
            rb.velocity = jumpvecor;
        }


        timeSinceStart += Time.deltaTime;
        float speed = speedCurve.Evaluate(timeSinceStart);

        Vector3 moveDirection = MoveDir * speed * moveSpeed;

        jumpfactor = Mathf.Sin(Time.timeSinceLevelLoad);

        stateDir = new Vector3( Mathf.LerpUnclamped(rb.position.x, Xdir[directionState],Time.deltaTime*4f), rb.position.y, rb.position.z);

        rb.MovePosition(stateDir + moveDirection * Time.deltaTime);

        DirChangeTimer += Time.deltaTime;

        targetRot = Vector3.Lerp(targetRot, Vector3.zero, Time.deltaTime * 4f);
        transform.eulerAngles = targetRot;
    }


    public void MoveRight()
    {
        if (DirChangeTimer < 1 )return;
        if(directionState < 2)
        directionState++;
        DirChangeTimer = 0;
        targetRot.y = 60;
    }
    public void MoveLeft()
    {
        if (DirChangeTimer < 1) return;
        if (directionState > 0)
            directionState--;
        DirChangeTimer = 0;
        targetRot.y = -60;
    }

    public void GetHitOnce()
    {
        anim.SetTrigger("stumble");
        PlayerCam.ins.Shake(2);
    }

    public LayerMask groundLayer;
    public float groundRadius = 0.2f;
    public bool CheckGrounded()
    {
        return Physics.CheckSphere(transform.position, groundRadius, groundLayer, QueryTriggerInteraction.Ignore);
    }
}
