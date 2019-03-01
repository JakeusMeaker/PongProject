using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Score : MonoBehaviour {

    private int score = 0;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject winText;
    [SerializeField]
    Arduino arduino;

    private void OnTriggerEnter(Collider other)
    {   
        /*when the object tagged "Ball" enters the trigger zone it will update the score and tell the arduino to light the corresponding LED and the ball is reset and relaunched. 
            when the score reaches 2 the win screen is activated and the Win coroutine is run*/
        if (other.gameObject.tag == "Ball")
        {
            Ball ball = other.gameObject.GetComponent<Ball>();
            if (score == 0)
            {
                arduino.WriteToArduino("c");
                score++;
                scoreText.text = "1";
                ball.Respawn();
            }

            else if (score == 1)
            {
                arduino.WriteToArduino("d");
                score++;
                scoreText.text = "2";
                ball.Respawn();
            }
            else if (score == 2)
            {
                winText.SetActive(true);
                StartCoroutine(Win());
            }
        }
    }

    IEnumerator Win()
    {
        //creates a loop that runs 3 times and makes the corresponding players LED's flash.

        int i = 3;

        while (i > 0) { 
        arduino.WriteToArduino("e");
        yield return new WaitForSeconds(0.2f);
        arduino.WriteToArduino("o");
        yield return new WaitForSeconds(0.2f);
            i--;
        }
        yield return null;

    }

    public void ResetScore()
    {
        //resets the score to 0 and also changes the text to 0
        score = 0;
        scoreText.text = "0";
    }


}
