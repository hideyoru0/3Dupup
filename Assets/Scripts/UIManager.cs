using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리자 관련 코드
using UnityEngine.UI; // UI 관련 코드
using TMPro;

// 필요한 UI에 즉시 접근하고 변경할 수 있도록 허용하는 UI 매니저
public class UIManager : MonoBehaviour
{
    // 싱글톤 접근용 프로퍼티
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }

            return m_instance;
        }
    }

    private static UIManager m_instance; // 싱글톤이 할당될 변수

    public Text stageText; // 스테이지 텍스트
    public Text titleText; // 타이틀 텍스트
    

    //// 스테이지 텍스트 갱신
    //public void StageText()
    //{
    //    stageText.SetActive(true);
    //}

    //// 타이틀 텍스트 갱신
    //public void TitleText()
    //{
    //    titleText.SetActive(true);
    //}

}