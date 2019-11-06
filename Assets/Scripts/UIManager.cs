using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager S;
    private UIManager() { }

    [SerializeField] private Text _scoreText;
    public int score { get; private set; }

    void Awake()
    {
        if (S == null)
            S = this;
    }

	void Start () {
        if (!_scoreText)
            _scoreText = GetComponentInChildren<Text>();
        score = 0;
        SetScoreText();
	}	

    public void AddScore(int score)
    {
        this.score += score;
        SetScoreText();
    }

    private void SetScoreText()
    {
        _scoreText.text = "Score: " + score;
    }

}
