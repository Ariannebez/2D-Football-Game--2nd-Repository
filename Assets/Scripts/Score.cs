using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] int scorenum = 1;
    [SerializeField] AudioClip scoresound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().addtoscore(scorenum);
        AudioSource.PlayClipAtPoint(scoresound, Camera.main.transform.position, 0.75f);

        int score = FindObjectOfType<GameSession>().getscore();

        if (score == 20)
        {
            FindObjectOfType<LevelManager>().LoadWinnerScene();
        }

        Destroy(collision.gameObject);

        
    }
}
