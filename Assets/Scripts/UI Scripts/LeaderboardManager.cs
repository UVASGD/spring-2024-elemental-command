using UnityEngine;
using TMPro;


using Dan.Main;

namespace LeaderboardCreatorDemo
{
    public class LeaderboardManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _entryTextObjects;
        [SerializeField] private TMP_InputField _usernameInputField;

// ------------------------------------------------------------
    //float unconvertedScore = TimerData.timerData;
        
        private int Score = Mathf.RoundToInt(TimerData.timerData * 100);
// ------------------------------------------------------------

        private void Start()
        {
            Debug.Log("Score = " + Score);
            LoadEntries();
        }

        private void LoadEntries()
        {
        
            Leaderboards.ElementalCommandLeaderboard.GetEntries(entries =>
            {
                foreach (var t in _entryTextObjects)
                    t.text = "";
                var length = Mathf.Min(_entryTextObjects.Length, entries.Length);
                for (int i = 0; i < length; i++)
                    _entryTextObjects[i].text = $"{entries[i].Rank}. {entries[i].Username} - {entries[i].Score}";
            });
        }
        
        public void UploadEntry()
        {
            Leaderboards.ElementalCommandLeaderboard.UploadNewEntry(_usernameInputField.text, Score, isSuccessful =>
            {
                if (isSuccessful){
                    Debug.Log("gets here");
                    LoadEntries();
                }
        
            });
        }
    }
}
