using UnityEngine;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
    public GameObject[] pages; // �y�[�W�ƂȂ�R���e���c�̔z��
    private int currentPageIndex = 0; // ���݂̃y�[�W�̃C���f�b�N�X

    void Start()
    {
        // �ŏ��̃y�[�W��\��
        ShowPage(currentPageIndex);
    }

    public void NextPage()
    {
        // ���̃y�[�W�ɐi��
        currentPageIndex = Mathf.Min(currentPageIndex + 1, pages.Length - 1);
        ShowPage(currentPageIndex);
    }

    public void PreviousPage()
    {
        // �O�̃y�[�W�ɖ߂�
        currentPageIndex = Mathf.Max(currentPageIndex - 1, 0);
        ShowPage(currentPageIndex);
    }

    void ShowPage(int pageIndex)
    {
        // �w�肳�ꂽ�y�[�W��\�����A���̃y�[�W���\���ɂ���
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex);
        }
    }
}
