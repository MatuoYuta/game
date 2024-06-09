using UnityEngine;

public class PageController : MonoBehaviour
{
    // �y�[�W�ƂȂ�R���e���c�̔z��
    public GameObject[] pages;

    // ���݂̃y�[�W�̃C���f�b�N�X
    private int currentPageIndex = 0;

    // �ŏ��̃t���[���̑O�ɌĂяo�����
    void Start()
    {
        // �ŏ��̃y�[�W��\��
        ShowPage(currentPageIndex);
    }

    // ���̃y�[�W�ɐi��
    public void NextPage()
    {
        currentPageIndex = Mathf.Min(currentPageIndex + 1, pages.Length - 1);
        ShowPage(currentPageIndex);
    }

    // �O�̃y�[�W�ɖ߂�
    public void PreviousPage()
    {
        currentPageIndex = Mathf.Max(currentPageIndex - 1, 0);
        ShowPage(currentPageIndex);
    }

    // �w�肳�ꂽ�y�[�W��\�����A���̃y�[�W���\���ɂ���
    void ShowPage(int pageIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex);
        }
    }
}
