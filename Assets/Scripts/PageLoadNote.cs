using UnityEngine;
using TMPro;
using System.IO;

public class PageLoadNote : MonoBehaviour
{
    private GameMaster gameMaster;
    private void Awake()
    {
        GameObject gm = GameObject.Find("GameMaster");
        gameMaster = gm.GetComponent<GameMaster>();
    }

    public GameObject[] _loadList;
    public TMP_Text[] _titleTexts;

    public void SynchronizePageLoadNote()
    {
        for (int i=0; i< _loadList.Length; i++)
        {
            string path = Path.Combine(Application.persistentDataPath, $"note{i}");

            if (!File.Exists(path))
            {
                _titleTexts[i].text = "EMPTY";
                continue;
            }

            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            _titleTexts[i].text = saveData._titleText;
        }
    }
}
