using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    private GameMaster gameMaster;
    [SerializeField] private GameObject[] _pages;
    
    private void Awake()
    {
        /*foreach(GameObject page in _pages)
        {
            page.SetActive(true);
        }*/
        
        gameMaster = GetComponentInParent<GameMaster>();
    }


    [SerializeField] private GameObject _returnButton;

    private enum SelectedPage { Main, NewNote, LoadNote, Note }
    private SelectedPage _selectedPage;

    public void CreateNewNoteButton() // main
    {
        SwitchPagesOff();
        _pages[1].gameObject.SetActive(true);
        gameMaster.notesManager.CreateNote();
        _returnButton.SetActive(true);
        _selectedPage = SelectedPage.NewNote;
        gameMaster.pageNewNote.ClearText();
    }

    public void LoadNotesButton() // main
    {
        SwitchPagesOff();
        _pages[2].gameObject.SetActive(true);
        _returnButton.SetActive(true);
        _selectedPage = SelectedPage.LoadNote;
        gameMaster.pageLoadNote.SynchronizePageLoadNote();
    }

    public void ReturnButton()
    {
        if (_selectedPage == SelectedPage.NewNote)
        {
            gameMaster.notesManager.RemoveNoteFromNewPage();
        }

        if (_selectedPage == SelectedPage.Note)
        {
            gameMaster.saveLoad.SavePage();
        }

        SwitchPagesOff();
        _pages[0].gameObject.SetActive(true);
        _returnButton.SetActive(false);
        gameMaster.notesManager._selectedNote = null;
        _selectedPage = SelectedPage.Main;
    }

    public void PageButton() // page_new_note
    {
        SwitchPagesOff();
        _pages[3].gameObject.SetActive(true);
        _selectedPage = SelectedPage.Note;
        gameMaster.pageNote.SynchronizeNote();
        gameMaster.pageNote.ClearAllText();
    }

    public void LoadPageButton(int id) // page_load_note
    {
        if (gameMaster.notesManager._notesList[id] == null) return;

        SwitchPagesOff();
        _pages[3].gameObject.SetActive(true);
        _selectedPage = SelectedPage.Note;
        gameMaster.notesManager.SynchronizeNote(id);
        gameMaster.pageNote.SynchronizeNote();
        gameMaster.saveLoad.LoadPage(id);
    }

    public void DeleteButton(int id)
    {
        gameMaster.notesManager.DeleteNote(id);
        gameMaster.pageLoadNote.SynchronizePageLoadNote();
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    #region PRIVATE AND CALLOUTS SECTOR

    private void SwitchPagesOff()
    {
        foreach (GameObject page in _pages)
        {
            page.gameObject.SetActive(false);
        }
    }

    public void FirstFrameSetMainPage()
    {
        SwitchPagesOff();
        _pages[0].gameObject.SetActive(true);
        _returnButton.SetActive(false);
    }

    #endregion
}
