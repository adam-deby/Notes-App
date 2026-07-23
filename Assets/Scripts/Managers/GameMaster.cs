using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public NotesManager notesManager { get; private set; }
    public ButtonsManager buttonsManager { get; private set; }
    public PageNewNote pageNewNote { get; private set; }
    public PageLoadNote pageLoadNote { get; private set; }
    public PageNote pageNote { get; private set; }
    public SaveLoadManager saveLoad { get; private set; }

    [SerializeField] private GameObject _pageContainer;
    private void Awake()
    {
        notesManager = GetComponentInChildren<NotesManager>();
        buttonsManager = GetComponentInChildren<ButtonsManager>();
        saveLoad = GetComponentInChildren<SaveLoadManager>();

        pageNewNote = _pageContainer.GetComponentInChildren<PageNewNote>(true);
        pageLoadNote = _pageContainer.GetComponentInChildren<PageLoadNote>(true);
        pageNote = _pageContainer.GetComponentInChildren<PageNote>(true);
    }

    public int _maxNotesAmount = 6;

    private void Start()
    {
        notesManager.CreateList(_maxNotesAmount);
        buttonsManager.FirstFrameSetMainPage();
        saveLoad.InitializeLoadPage();
    }
}
