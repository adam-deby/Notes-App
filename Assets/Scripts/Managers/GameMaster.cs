using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public NotesManager notesManager { get; private set; }
    public ButtonsManager buttonsManager { get; private set; }
    public PageNewNote pageNewNote { get; private set; }
    public PageLoadNote pageLoadNote { get; private set; }
    public PageNote pageNote { get; private set; }
    public SaveLoadManager saveLoad { get; private set; }
    private void Awake()
    {
        notesManager = GetComponentInChildren<NotesManager>();
        buttonsManager = GetComponentInChildren<ButtonsManager>();
        saveLoad = GetComponentInChildren<SaveLoadManager>();

        GameObject pageNewObject = GameObject.Find("page_new_note");
        pageNewNote = pageNewObject.GetComponent<PageNewNote>();

        GameObject pageLoadObject = GameObject.Find("page_load_note");
        pageLoadNote = pageLoadObject.GetComponent<PageLoadNote>();

        GameObject pageNoteObject = GameObject.Find("page_note");
        pageNote = pageNoteObject.GetComponent<PageNote>();
    }

    public int _maxNotesAmount = 6;

    private void Start()
    {
        notesManager.CreateList(_maxNotesAmount);
        buttonsManager.FirstFrameSetMainPage();
        saveLoad.InitializeLoadPage();
    }
}
