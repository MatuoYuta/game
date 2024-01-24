using UnityEngine;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
    public GameObject[] pages; // ページとなるコンテンツの配列
    private int currentPageIndex = 0; // 現在のページのインデックス

    void Start()
    {
        // 最初のページを表示
        ShowPage(currentPageIndex);
    }

    public void NextPage()
    {
        // 次のページに進む
        currentPageIndex = Mathf.Min(currentPageIndex + 1, pages.Length - 1);
        ShowPage(currentPageIndex);
    }

    public void PreviousPage()
    {
        // 前のページに戻る
        currentPageIndex = Mathf.Max(currentPageIndex - 1, 0);
        ShowPage(currentPageIndex);
    }

    void ShowPage(int pageIndex)
    {
        // 指定されたページを表示し、他のページを非表示にする
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex);
        }
    }
}
