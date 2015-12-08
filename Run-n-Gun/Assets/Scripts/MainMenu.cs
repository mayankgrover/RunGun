using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class MainMenu : MonoBehaviour
{
    public Button PlayBots;
    public Button PlayYouself;

    void Awake()
    {
        PlayBots.onClick.AddListener(OnPlayBots);
        PlayYouself.onClick.AddListener(OnPlayYourself);
    }

    private void OnPlayBots()
    {
        PlayerPrefs.SetInt(PlayerType.Bot.ToString(), 1);
        PlayerPrefs.SetInt(PlayerType.MyClone.ToString(), 0);
        StartGame();
    }

    private void StartGame()
    {
        //Application.LoadLevel("2dCharacter");
        Application.LoadLevel("2D Art scene");
    }

    private void OnPlayYourself()
    {
        PlayerPrefs.SetInt(PlayerType.Bot.ToString(), 0);
        PlayerPrefs.SetInt(PlayerType.MyClone.ToString(), 1);
        StartGame();
    }
}
