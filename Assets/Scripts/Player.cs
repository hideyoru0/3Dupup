using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;   //UI ����� ���ؼ� �߰�

public class Player : MonoBehaviour
{
    public float speed;
    public Follow follow; //������ �÷��̾�� ī�޶� �̵�
    public GameManager gameManager;
    public GameObject UIRestartBtn;
    public GameObject UIExitBtn;
    public Text UIStage;
    public AudioClip deathClip;

    private AudioSource playerAudio;

    /// <summary>
    /// ���̽�ƽ ��Ʈ�� �̿ϼ�
    /// </summary>
    public bool[] joyControl;
    public bool isControl;
    public bool isButtonA;
    public bool isButtonB;
    /// <summary>
    /// 
    /// </summary>
    
    float hAxis;
    float vAxis;
    bool wDown;
    bool jDown;
    bool isJump;

    Vector3 moveVec;

    Animator anim;
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();  //Player �ڽ� ������Ʈ�� �����Ƿ�
        follow = FindFirstObjectByType<Follow>(); //������ �÷��̾�� ī�޶� �̵�
        gameManager = FindFirstObjectByType<GameManager>(); //���� �Ŵ��� ���
    }

    void Start()
    {
        follow.target = this.transform;    //������ �÷��̾�� ī�޶� �̵�
        gameManager.player = this;         //���� �Ŵ����� ������ �÷��̾ �� ��ũ��Ʈ�� ����
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal"); //�¿� ����Ű
        vAxis = Input.GetAxisRaw("Vertical");   //���� ����Ű
        wDown = Input.GetButton("Walk");    //shift Ű
        jDown = Input.GetButtonDown("Jump"); //�����̽���
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;  //normalized : ���� ���� 1�� ������ ����

        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        anim.SetBool("isRun", (moveVec != Vector3.zero));   //�̵��� ���߸�
        anim.SetBool("isWalk", wDown);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec); //���ư� ���� ����
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * 15, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
        else if (collision.gameObject.tag == "DeadZone")
        {
            anim.SetBool("doDodge", true);
            isJump = false;
            //����� ��ư UI
            gameManager.UIRestartBtn.SetActive(true);
            gameManager.UIExitBtn.SetActive(true);
            TextMeshProUGUI btnText = gameManager.UIRestartBtn.GetComponentInChildren<TextMeshProUGUI>();   //��ư �ؽ�Ʈ�� �ڽ� ������Ʈ�̹Ƿ� InChildren�� �ٿ�����
            TextMeshProUGUI ExitbtnText = gameManager.UIExitBtn.GetComponentInChildren<TextMeshProUGUI>();

            // ����� �������� �ؽ�Ʈ ����
            UIManager.instance.stageText.gameObject.SetActive(false);

            // ��� ����� ���
            playerAudio.clip = deathClip;
            playerAudio.Play();

            //����� 3�� �� ���߱�(��� �ִ� ����ȵ�)
            //new WaitForSeconds(3);
            //Time.timeScale = 0;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "SuperFloor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
            //�浹�� ƨ����
            //��ǥ�� ���� ���ʿ��� ������ ��������, �����ʿ��� ������ ����������
            OnJumpFloor();
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            //���� ���������� �̵�
            gameManager.NextStage();
        }
    }


    void OnJumpFloor()
    {   
        //�浹�� ƨ����
        //��ǥ�� ���� ���ʿ��� ������ ��������, �����ʿ��� ������ ����������
        //int dirc = transform.position.y - targetPos.y > 0 ? 1 : -1;
        rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }

    public void VelocityZero()
    {
        rigid.velocity = Vector3.zero;
    }
}