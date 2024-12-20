using UnityEngine;
using UnityEngine.SceneManagement; // �� ������ ���� �ڵ�
using UnityEngine.UI; // UI ���� �ڵ�
using TMPro;

// �ʿ��� UI�� ��� �����ϰ� ������ �� �ֵ��� ����ϴ� UI �Ŵ���
public class UIManager : MonoBehaviour
{
    // �̱��� ���ٿ� ������Ƽ
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

    private static UIManager m_instance; // �̱����� �Ҵ�� ����

    public Text stageText; // �������� �ؽ�Ʈ
    public Text titleText; // Ÿ��Ʋ �ؽ�Ʈ
    

    //// �������� �ؽ�Ʈ ����
    //public void StageText()
    //{
    //    stageText.SetActive(true);
    //}

    //// Ÿ��Ʋ �ؽ�Ʈ ����
    //public void TitleText()
    //{
    //    titleText.SetActive(true);
    //}

}