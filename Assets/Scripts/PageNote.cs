using UnityEngine;
using TMPro;

public class PageNote : MonoBehaviour
{
    private GameMaster gameMaster;
    private void Awake()
    {
        GameObject gm = GameObject.Find("GameMaster");
        gameMaster = gm.GetComponent<GameMaster>();
    }

    public TMP_InputField inputField;
    [SerializeField] private TMP_Text _titleText; 
    private NoteScript noteScript;

    private void Start()
    {
        inputField.onValueChanged.AddListener(ChangeText);
    }

    public void SynchronizeNote()
    {
        noteScript = gameMaster.notesManager._selectedNote.gameObject.GetComponent<NoteScript>();
        _titleText.text = noteScript._noteTitle;
    }

    public void LoadNote(string titleText, string text)
    {
        noteScript._noteTitle = titleText;
        noteScript._noteText = text;

        _titleText.text = titleText;
        inputField.text = text;
    }

    public void ClearAllText()
    {
        inputField.text = "";
    }

    private void ChangeText(string text)
    {
        noteScript._noteText = text;
        gameMaster.saveLoad.SavePage();
    }
}
