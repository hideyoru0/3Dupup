using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI ����� ���ؼ� �߰�
using UnityEngine.SceneManagement;   //Scene ��ȯ�� ���ؼ� �߰�


public class GameManager : MonoBehaviour
{
    public int stageIndex;  //�������� ��ȣ
    public GameObject[] Stages;
    public Player player;
    public Text UIStage;
    public GameObject UIRestartBtn;
    public GameObject UIExitBtn;
    public bool isGameover { get; private set; } // ���� ���� ����
    public bool isGameStart { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // ���ӽ��۽� Ÿ�̸� ����
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !isGameStart)
        {
            // ���� ���۽� UI �ѱ�
            UIManager.instance.titleText.transform.parent.gameObject.SetActive(true); // Ÿ��Ʋ �ؽ�Ʈ �ڽ����� �� �ؽ�Ʈ���� �����´�
            UIManager.instance.stageText.gameObject.SetActive(true);

            isGameStart = true;
            // ���� ���� �� Ÿ��Ʋ ����
            UIManager.instance.titleText.gameObject.SetActive(false);
        }
    }

    void PlayerReposition()
    {   //�÷��̾� ��ġ �ǵ����� �Լ�
        player.transform.position = new Vector3(-5.0f, 5.0f, 5.0f);  //�÷��̾� ��ġ �̵�
        player.VelocityZero();  //�÷��̾� ���� �ӵ� 0���� �����
    }

    public void NextStage()
    {
        //���� ���������� �̵�
        if (stageIndex < Stages.Length - 1)
        {
            Stages[stageIndex].SetActive(false);    //���� �������� ��Ȱ��ȭ
            stageIndex++;
            Stages[stageIndex].SetActive(true); //���� �������� Ȱ��ȭ
            PlayerReposition();

            UIStage.text = "STAGE " + (stageIndex + 1);
        }
        else
        {  //���� Ŭ�����
            //���߱�
            //Time.timeScale = 0;

            //����� ��ư UI
            UIRestartBtn.SetActive(true);
            Text btnText = UIRestartBtn.GetComponentInChildren<Text>();   //��ư �ؽ�Ʈ�� �ڽ� ������Ʈ�̹Ƿ� InChildren�� �ٿ�����
            btnText.text = "Clear!";
            UIRestartBtn.SetActive(true);
        }
    }

    public void Restart()
    {
        //Time.timeScale = 1; //����۽� �ð� ����
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
