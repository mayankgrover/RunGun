using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class ScoreManager : MonoBehaviour
{
    public PlatformerCharacter2D myPlayer;
    private Text score;

    void Awake()
    {
        score = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
	}

    public void UpdateScore()
    {
        score.text = "Arrows: " + myPlayer.ArrowCount;
    }
}
