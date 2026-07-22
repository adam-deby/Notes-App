using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NotesManager : MonoBehaviour
{
    private GameMaster gameMaster;
    private void Awake()
    {
        gameMaster = GetComponentInParent<GameMaster>();
    }

    [SerializeField] private NoteScript _notesPrefab;
    [SerializeField] private Transform _notesContainer;
    [SerializeField] private List<NoteScript> _notesList = new List<NoteScript>();
    public GameObject _selectedNote;

    public void CreateList(int amount)
    {
        for (int i=0;i<amount;i++)
        {
            _notesList.Add(null);
        }
    }

    public void CreateNote()
    {
        for (int i=0;i< _notesList.Count;i++)
        {
            if (_notesList[i] != null)
            {
                if (i == _notesList.Count - 1)
                {
                    gameMaster.buttonsManager.ReturnButton();
                    break;
                }

                continue;
            }

            NoteScript thisObject = Instantiate(_notesPrefab, _notesContainer);
            _notesList[i] = thisObject;
            _selectedNote = thisObject.gameObject;
            thisObject._noteID = i;
            gameMaster.pageNewNote.InitializeNewPageNote(i);
            break;
        }
    }

    public void CreateSpecificNote(int id)
    {
        if (_notesList[id] != null) return;

        NoteScript thisObject = Instantiate(_notesPrefab, _notesContainer);
        _notesList[id] = thisObject;
    }

    public void SynchronizeNote(int id)
    {
        for (int i=0;i< _notesList.Count;i++)
        {
            if (id != i) continue;

            _selectedNote = _notesList[i].gameObject;
        }
    }

    public void DeleteNote(int id)
    {
        for (int i=0;i<_notesList.Count;i++)
        {
            if (id != i) continue;

            gameMaster.saveLoad.RemovePageSave(i);

            Destroy(_notesList[i].gameObject);
        }
    }

    public void RemoveNoteFromNewPage()
    {
        Destroy(_selectedNote.gameObject);
        _selectedNote = null;
    }
}
