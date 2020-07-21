using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class gameSettings : MonoBehaviour
{
    public float startPos = -7.52f;
    public float endPos = 6;
    public float totalDistance = 13.52f;
    public float totalBasePoints = 30f;
    public float baseValue = 1f;
    public float midValue = 2f;
    public float maxValue = 5f;

    public float baseDistance;
    public float midDistance;
    public float maxDistance;

    public bool gameInProgress = false;

    public GameObject kameel1;
    public GameObject kameel2;
    public GameObject kameel3;
    public GameObject kameel4;

    public GameObject topText;
    public GameObject bottomText;

    private int counter;


    public int countDownTime = 10;
    public int readyTimer = 5;

    public bool canJoin = false;

    public int gameTimeOut = 300;

    public AudioClip a_jingle;
    public AudioClip a_bugle;
    public AudioClip a_kameel1;
    public AudioClip a_kameel2;
    public AudioClip a_kameel3;
    public AudioClip a_kameel4;
    public AudioClip a_runningSound;
    public AudioClip a_timeout;
    public AudioClip a_triggerHit;
    public AudioClip a_winner;
    public AudioClip a_join;

    private DateTime lastJingle;



    // Start is called before the first frame update
    void Start()
    {

        //calculate distances
        totalDistance = endPos - startPos;
        baseDistance = (totalDistance / totalBasePoints) * baseValue;
        midDistance = (totalDistance / totalBasePoints) * midValue;
        maxDistance = (totalDistance / totalBasePoints) * maxValue;

        //initialise join counter
        counter = countDownTime;

        //start join game state
        //first time audio
        gameObject.GetComponent<AudioSource>().loop = false;
        gameObject.GetComponent<AudioSource>().clip = a_jingle;
        gameObject.GetComponent<AudioSource>().Play();
        lastJingle = DateTime.Now;
        countDownGame();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F12))
        {
            Application.Quit();
        }
    }

    public void triggerWin(int playerNumber)
    {
        gameInProgress = false;
        Invoke("playWinSound", 0.5f);
        bottomText.GetComponent<UnityEngine.UI.Text>().text = "Einde ronde!\nWinnaar: speler " + playerNumber + ".";
        Invoke("resetCamels", 13f);
    }

    public void playWinSound()
    {
        gameObject.GetComponent<AudioSource>().loop = false;
        gameObject.GetComponent<AudioSource>().clip = a_winner;
        gameObject.GetComponent<AudioSource>().Play();
    }

    private void countDownGame()
    {
        if (counter == countDownTime && gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            if ((DateTime.Now - lastJingle).Minutes > 2)
            {
                gameObject.GetComponent<AudioSource>().loop = false;
                gameObject.GetComponent<AudioSource>().clip = a_jingle;
                gameObject.GetComponent<AudioSource>().Play();
                lastJingle = DateTime.Now;
            }
        }
        canJoin = true;
        gameInProgress = false;
        bottomText.GetComponent<UnityEngine.UI.Text>().text = "Druk op de startknop om mee te spelen\nVolgende ronde start in " + counter + " seconden...";
        counter--;
        if (counter == -1)
        {
            //check for players
            if(kameel1.GetComponent<kameelscript>().isPlaying == false && kameel2.GetComponent<kameelscript>().isPlaying == false && kameel3.GetComponent<kameelscript>().isPlaying == false && kameel4.GetComponent<kameelscript>().isPlaying == false)
            {
                // no players, reset counter
                counter = countDownTime;
                Invoke("countDownGame", 1f);
            }
            else
            {
                // at least one player joined, moving to next step (readyup)
                gameObject.GetComponent<AudioSource>().clip = a_bugle;
                gameObject.GetComponent<AudioSource>().Play();
                counter = readyTimer;
                Invoke("readyUp", 0f);
            }
        }
        else
        {
            //count down one second...
            Invoke("countDownGame", 1f);
        }
       
    }

    public void runningSound()
    {
        gameObject.GetComponent<AudioSource>().clip = a_runningSound;
        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().Play();
    }

    private void readyUp()
    {
        canJoin = false;
        bottomText.GetComponent<UnityEngine.UI.Text>().text = "Klaar om te starten!\nBegin in " + counter + " seconden!";
        counter--;
        if(counter == -1)
        {
            //start game
            gameInProgress = true;
            bottomText.GetComponent<UnityEngine.UI.Text>().text = "START!";
            Invoke("runningSound", 1f);
            counter = gameTimeOut;
            Invoke("countTimeOut", 0f);
        }
        else
        {
            //count down one second...
            Invoke("readyUp", 1f);
        }
    }


    private void resetCamels()
    {

        //reset camels to begin position
        kameel1.transform.position = new Vector2(startPos, 0.372f);
        kameel2.transform.position = new Vector2(startPos, -1.198f);
        kameel3.transform.position = new Vector2(startPos, -2.698f);
        kameel4.transform.position = new Vector2(startPos, -4.198f);

        //reset isPlaying vars
        kameel1.GetComponent<kameelscript>().isPlaying = false;
        kameel2.GetComponent<kameelscript>().isPlaying = false;
        kameel3.GetComponent<kameelscript>().isPlaying = false;
        kameel4.GetComponent<kameelscript>().isPlaying = false;

        //trigger getdown animation when camels are not down already
        if (kameel1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("kameel_idle2"))
        {
            // do nothing
        }
        else
        {
            kameel1.GetComponent<kameelscript>().getDown();
        }
        if (kameel2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("kameel_idle2"))
        {
            // do nothing
        }
        else
        {
            kameel2.GetComponent<kameelscript>().getDown();
        }
        if (kameel3.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("kameel_idle2"))
        {
            // do nothing
        }
        else
        {
            kameel3.GetComponent<kameelscript>().getDown();
        }
        if (kameel4.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("kameel_idle2"))
        {
            // do nothing
        }
        else
        {
            kameel4.GetComponent<kameelscript>().getDown();
        }

        //reset to game join state
        counter = countDownTime;
        Invoke("countDownGame",0f);

    }

    private void countTimeOut()
    {
        // if idle during game, reset camels and go back to game join state
        if(gameInProgress == true)
        {
            if (counter == -1)
            {
                gameInProgress = false;
                bottomText.GetComponent<UnityEngine.UI.Text>().text = "Einde spel (timeout).";
                gameObject.GetComponent<AudioSource>().clip = a_timeout;
                gameObject.GetComponent<AudioSource>().loop = false;
                gameObject.GetComponent<AudioSource>().Play();
                Invoke("resetCamels", 5f);
            }
            else
            {
                counter--;
                Invoke("countTimeOut", 1f);
            }

        }
    }
}
