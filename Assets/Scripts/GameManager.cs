using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI 사용을 위해서 추가
using UnityEngine.SceneManagement;   //Scene 전환을 위해서 추가


public class GameManager : MonoBehaviour
{
    public int stageIndex;  //스테이지 번호
    public GameObject[] Stages;
    public Player player;
    public Text UIStage;
    public GameObject UIRestartBtn;
    public GameObject UIExitBtn;
    public bool isGameover { get; private set; } // 게임 오버 상태
    public bool isGameStart { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // 게임시작시 타이머 시작
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !isGameStart)
        {
            // 게임 시작시 UI 켜기
            UIManager.instance.titleText.transform.parent.gameObject.SetActive(true); // 타이틀 텍스트 자식으로 된 텍스트까지 가져온다
            UIManager.instance.stageText.gameObject.SetActive(true);

            isGameStart = true;
            // 게임 시작 후 타이틀 끄기
            UIManager.instance.titleText.gameObject.SetActive(false);
        }
    }

    void PlayerReposition()
    {   //플레이어 위치 되돌리기 함수
        player.transform.position = new Vector3(-5.0f, 5.0f, 5.0f);  //플레이어 위치 이동
        player.VelocityZero();  //플레이어 낙하 속도 0으로 만들기
    }

    public void NextStage()
    {
        //다음 스테이지로 이동
        if (stageIndex < Stages.Length - 1)
        {
            Stages[stageIndex].SetActive(false);    //현재 스테이지 비활성화
            stageIndex++;
            Stages[stageIndex].SetActive(true); //다음 스테이지 활성화
            PlayerReposition();

            UIStage.text = "STAGE " + (stageIndex + 1);
        }
        else
        {  //게임 클리어시
            //멈추기
            //Time.timeScale = 0;

            //재시작 버튼 UI
            UIRestartBtn.SetActive(true);
            Text btnText = UIRestartBtn.GetComponentInChildren<Text>();   //버튼 텍스트는 자식 오브젝트이므로 InChildren을 붙여야함
            btnText.text = "Clear!";
            UIRestartBtn.SetActive(true);
        }
    }

    public void Restart()
    {
        //Time.timeScale = 1; //재시작시 시간 복구
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
