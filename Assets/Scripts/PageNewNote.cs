using UnityEngine;
using TMPro;


public class PageNewNote : MonoBehaviour
{
    private GameMaster gameMaster;
    private void Awake()
    {
        GameObject gm = GameObject.Find("GameMaster");
        gameMaster = gm.GetComponent<GameMaster>();
    }

    public TMP_InputField inputField;
    [SerializeField] private TMP_Text _idText;

    private void Start()
    {
        inputField.onValueChanged.AddListener(AddTitleText);
    }

    public void InitializeNewPageNote(int pageID)
    {
        _idText.text = $"id: {pageID}";
    }

    private void AddTitleText(string text)
    {
        NoteScript note = gameMaster.notesManager._selectedNote.GetComponent<NoteScript>();
        note._noteTitle = text.ToString();
    }

    public void ClearText()
    {
        inputField.text = "";
    }
}
