using UnityEngine;

public class PageController : MonoBehaviour
{
    // ページとなるコンテンツの配列
    public GameObject[] pages;

    // 現在のページのインデックス
    private int currentPageIndex = 0;

    // 最初のフレームの前に呼び出される
    void Start()
    {
        // 最初のページを表示
        ShowPage(currentPageIndex);
    }

    // 次のページに進む
    public void NextPage()
    {
        currentPageIndex = Mathf.Min(currentPageIndex + 1, pages.Length - 1);
        ShowPage(currentPageIndex);
    }

    // 前のページに戻る
    public void PreviousPage()
    {
        currentPageIndex = Mathf.Max(currentPageIndex - 1, 0);
        ShowPage(currentPageIndex);
    }

    // 指定されたページを表示し、他のページを非表示にする
    void ShowPage(int pageIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex);
        }
    }
}
