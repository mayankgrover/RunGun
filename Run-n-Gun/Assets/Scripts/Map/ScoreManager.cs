using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class ScoreManager : MonoBehaviour
{
    public PlatformerCharacter2D myPlayer;
    public Text arrowsLeft, kills;

    public static ScoreManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
	}

    public void UpdateScore()
    {
        arrowsLeft.text = "Arrows: " + myPlayer.ArrowCount;
    }

    public void IncrementKills()
    {
        myPlayer.IncrementKills();
        kills.text = "Kills: " + myPlayer.KillCount;
    }
}
