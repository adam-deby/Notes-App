using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private GameMaster gameMaster;
    private NotesManager notesManager;
    private void Awake()
    {
        gameMaster = GetComponentInParent<GameMaster>();
        notesManager = gameMaster.GetComponentInChildren<NotesManager>();
    }

    public void SavePage()
    {
        SaveData saveData = new SaveData();
        NoteScript noteScript = notesManager._selectedNote.GetComponent<NoteScript>();

        saveData._id = noteScript._noteID;
        saveData._titleText = noteScript._noteTitle;
        saveData._text = noteScript._noteText;

        string json = JsonUtility.ToJson(saveData);
        string path = Path.Combine(Application.persistentDataPath, $"note{noteScript._noteID}");

        File.WriteAllText(path, json);
    }

    public void LoadPage(int id)
    {
        string path = Path.Combine(Application.persistentDataPath, $"note{id}");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            string titleText = saveData._titleText;
            string text = saveData._text;
            gameMaster.pageNote.LoadNote(titleText, text);
        }
    }

    public void InitializeLoadPage()
    {
        for (int i=0;i<6;i++)
        {
            string path = Path.Combine(Application.persistentDataPath, $"note{i}");

            if (!File.Exists(path)) continue;

            gameMaster.notesManager.CreateSpecificNote(i);
        }
    }
    
    public void RemovePageSave(int id)
    {
        string path = Path.Combine(Application.persistentDataPath, $"note{id}");
        if (!File.Exists(path)) return;

        File.Delete(path);
    }
}
