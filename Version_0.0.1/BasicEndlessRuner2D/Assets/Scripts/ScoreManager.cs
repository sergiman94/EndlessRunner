using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

	public bool shouldDouble;

    // Use this for initialization
    void Start()
    {

        if (PlayerPrefs.HasKey("HighScore"))
        {

            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (scoreIncreasing)
        {

            scoreCount += pointsPerSecond * Time.deltaTime;
        }


        if (scoreCount > highScoreCount)
        {

            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round(highScoreCount);

    }

    public void AddScore(int pointsToAdd)
    {
		if (shouldDouble) {

			pointsToAdd = pointsToAdd * 2;
		}

        scoreCount += pointsToAdd;

    }
}
