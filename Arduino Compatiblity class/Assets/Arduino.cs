using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class Arduino : MonoBehaviour {

    public GameObject playerOne;
    public GameObject playerTwo;
    public int commPort = 0;
    public float scaleSize = 10f;

    private SerialPort serial;

	// Use this for initialization
	void Start () {
        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
        serial.ReadTimeout = 50;
        serial.Open();
        Restart();
	}
	
	// Update is called once per frame
	void Update () {
        WriteToArduino("P");
        string values = ReadFromArduino(); Debug.Log(values);

        if(values != null)
        {
            string[] splitValues = values.Split('-');

            if(splitValues.Length == 2)
            {
                positionPlayers(splitValues);
            }
        }
	}

    void positionPlayers(string[] values)
    {
        if(playerOne != null)
        {
            //float scale = Remap(int.Parse(values[0]), 0f, 1023f, 0f, scaleSize);
            //Vector3 newPosition1 = new Vector3(playerOne.transform.position.x,
            //  scale, playerOne.transform.position.z);

            //playerOne.transform.position = newPosition1;

            float p1TempValues = float.Parse(values[0]);

            p1TempValues -= 10;

            p1TempValues /= 3;

            p1TempValues = 10 - p1TempValues;

            playerOne.transform.position = new Vector3(playerOne.transform.position.x, p1TempValues, playerOne.transform.position.z);

        }

        if (playerTwo != null)
        {
            /*float scale = Remap(int.Parse(values[1]), 0f, 1023f, 0f, scaleSize);
            Vector3 newPosition2 = new Vector3(playerTwo.transform.position.x,
                scale, playerTwo.transform.position.z);

            playerTwo.transform.position = newPosition2;*/

            float p1TempValues = float.Parse(values[1]);

            p1TempValues -= 10;

            p1TempValues /= 3;

            p1TempValues = 10 - p1TempValues;

            playerTwo.transform.position = new Vector3(playerTwo.transform.position.x, p1TempValues, playerTwo.transform.position.z);


        }
    }

    public void WriteToArduino(string msg)
    {
        serial.WriteLine(msg);
        serial.BaseStream.Flush();
    }

    string ReadFromArduino()
    {
        serial.ReadTimeout = 50;
        try
        {
            return serial.ReadLine();
        }
        catch (TimeoutException e)
        {
            return null;
        }
    }

    public void OnDestroy()
    {
        serial.Close();
    }

    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return ( value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    public void Restart()
    {
        WriteToArduino("r");

    }
    
}

