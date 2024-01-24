[SerializeField] private Text Text_Title;
[SerializeField] private Text Text_Contents;
[SerializeField] private Button _ButtonNext;
[SerializeField] private Button _ButtonPrevious;
public List<Blog> BlogList = new List<Blog>();
private int _MaxPageNumber;
private int _NowPageNumber = 1;
void Start()
{
    _MaxPageNumber = BlogList.Count;
    ChangeContents(_NowPageNumber);
    _ButtonNext.onClick.AddListener(OnNextPaper);
    _ButtonPrevious.onClick.AddListener(OnPreviousPaper);

}


[System.Serializable]
public class Blog
{
    public string Title;
    [TextArea(1, 10)] public string Contents;


    public Blog(string title, string contents)
    {
        Title = title;
        Contents = contents;
    }
}

private void OnNextPaper()
{
    if (_NowPageNumber != _MaxPageNumber)
    {
        ChangeContents(_NowPageNumber + 1);
    }

}

private void OnPreviousPaper()
{
    if (_NowPageNumber != 1)
    {
        ChangeContents(_NowPageNumber - 1);
    }

}
private void ChangeContents(int pageNumber)
{
    _NowPageNumber = pageNumber;

    Text_Title.text = BlogList[pageNumber - 1].Title;
    Text_Contents.text = BlogList[pageNumber - 1].Contents;

}