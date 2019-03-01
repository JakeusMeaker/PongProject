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
        if (other.gameObject.tag == "Ball")
        {
            Ball ball = other.gameObject.GetComponent<Ball>();
            if (score == 0)
            {
                arduino.WriteToArduino("a");
                score++;
                scoreText.text = "1";
                ball.Respawn();
            }

            else if (score == 1)
            {
                arduino.WriteToArduino("b");
                score++;
                winText.SetActive(true);
                Win();
            }
        }
    }

    IEnumerator Win()
    {
        arduino.WriteToArduino("w");
        yield return new WaitForSeconds(0.2f);
        arduino.WriteToArduino("o");
        yield return new WaitForSeconds(0.2f);
        arduino.WriteToArduino("w");
        yield return new WaitForSeconds(0.2f);
        arduino.WriteToArduino("o");
        yield return null;

    }

    public void ResetScore()
    {
        score = 0;
    }


}
