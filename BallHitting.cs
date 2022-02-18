using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitting : MonoBehaviour
{
    bool hitting;

    float speed = 3f;
    float force = 15;

    public Transform aimTarget;

    Animator animator;

    public Transform ball;

    ShotManager shotManager;
    shot currentShot;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        shotManager = GetComponent<ShotManager>();
        currentShot = shotManager.lineDrive;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Collider>().isTrigger = false;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        ball.position += transform.right * (Time.deltaTime * 4);

        if(Input.GetKeyDown(KeyCode.L))
        {
            hitting = true;
            currentShot = shotManager.lineDrive;
            GetComponent<Collider>().isTrigger = true;
            animator.Play("Swing");
        }else if(Input.GetKeyUp(KeyCode.L))
        {
            hitting = false;
            GetComponent<Collider>().isTrigger = false;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            hitting = true;
            currentShot = shotManager.highHit;
            GetComponent<Collider>().isTrigger = true;
            animator.Play("Swing");
        }else if(Input.GetKeyUp(KeyCode.P))
        {
            hitting = false;
            GetComponent<Collider>().isTrigger = false;
        }

        if(hitting)
        {
            aimTarget.Translate(new Vector3(h, 0, 0) * speed * Time.deltaTime);
        }

        if(h != 0 || v != 0 && ! hitting)
        {
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);

            Vector3 ballDir = ball.position - transform.position;
        }
    }
}
