using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class kameelscript : MonoBehaviour
{
    public Animator anim;
    public int player;
    public float speed = 5.0f;
    private Vector2 target;
    private Vector2 position;
    private float distance = 0;
    private GameObject gameSettingsObject;
    public bool isPlaying = false;
    public bool firstTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        target = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        gameSettingsObject = GameObject.Find("gameSettings");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        // fix position for getup/getdown animation problem on game end
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("kameel_getdown"))
        {
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }

        //get input when game in running and set new position
        if (gameSettingsObject.GetComponent<gameSettings>().gameInProgress == true && isPlaying == true)
        {
            // fix position for getup/getdown animation problem on game start
            if(firstTarget == true)
            {
                target = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                firstTarget = false;
            }
            switch (player)
            {
                case 1:
                    //top score
                    if (Input.GetKeyUp(KeyCode.X))
                    {
                        anim.Play("kameel_running2",-1,0);
                        position = gameObject.transform.position;
                        distance = gameSettingsObject.GetComponent<gameSettings>().maxDistance;
                        target = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
                        playTriggerHit();
                        Invoke("trySoundBite", 2f);
                        break;
                    }

                    //mid score
                    if (Input.GetKeyUp(KeyCode.B))
                    {
                        anim.Play("kameel_running2", -1, 0);
                        position = gameObject.transform.position;
                        distance = gameSettingsObject.GetComponent<gameSettings>().midDistance;
                        target = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
                        playTriggerHit();
                        Invoke("trySoundBite", 2f);
                        break;
                    }

                    //low score
                    if (Input.GetKeyUp(KeyCode.C))
                    {
                        anim.Play("kameel_running2", -1, 0);
                        position = gameObject.transform.position;
                        distance = gameSettingsObject.GetComponent<gameSettings>().baseDistance;
                        target = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
                        playTriggerHit();
                        Invoke("trySoundBite", 2f);
                        break;
                    }
                    break;
                case 2:
                    //top score
                    if (Input.GetKeyUp(KeyCode.D))
                    {
                        anim.Play("kameel_running2", -1, 0);
                        position = gameObject.transform.position;
                        distance = gameSettingsObject.GetComponent<gameSettings>().maxDistance;
                        target = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
                        playTriggerHit();
                        Invoke("trySoundBite", 2f);
                        break;
                    }

                    //mid score
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        anim.Play("kameel_running2", -1, 0);
                        position = gameObject.transform.position;
                        distance = gameSettingsObject.GetComponent<gameSettings>().midDistance;
                        target = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
                        playTriggerHit();
                        Invoke("trySoundBite", 2f);
                        break;
                    }

                    //low score
                    if (Input.GetKeyUp(KeyCode.F))
                    {
                        anim.Play("kameel_running2", -1, 0);
                        position = gameObject.transform.position;
                        distance = gameSettingsObject.GetComponent<gameSettings>().baseDistance;
                        target = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
                        playTriggerHit();
                        Invoke("trySoundBite", 2f);
                        break;
                    }
                    break;
                case 3:
                    //top score
                    if (Input.GetKeyUp(KeyCode.G))
                    {
                        anim.Play("kameel_running2", -1, 0);
                        position = gameObject.transform.position;
                        distance = gameSettingsObject.GetComponent<gameSettings>().maxDistance;
                        target = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
                        playTriggerHit();
                        Invoke("trySoundBite", 2f);
                        break;
                    }

                    //mid score
                    if (Input.GetKeyUp(KeyCode.H))
                    {
                        anim.Play("kameel_running2", -1, 0);
                        position = gameObject.transform.position;
                        distance = gameSettingsObject.GetComponent<gameSettings>().midDistance;
                        target = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
                        playTriggerHit();
                        Invoke("trySoundBite", 2f);
                        break;
                    }

                    //low score
                    if (Input.GetKeyUp(KeyCode.I))
                    {
                        anim.Play("kameel_running2", -1, 0);
                        position = gameObject.transform.position;
                        distance = gameSettingsObject.GetComponent<gameSettings>().baseDistance;
                        target = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
                        playTriggerHit();
                        Invoke("trySoundBite", 2f);
                        break;
                    }
                    break;
                case 4:
                    //top score
                    if (Input.GetKeyUp(KeyCode.J))
                    {
                        anim.Play("kameel_running2", -1, 0);
                        position = gameObject.transform.position;
                        distance = gameSettingsObject.GetComponent<gameSettings>().maxDistance;
                        target = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
                        playTriggerHit();
                        Invoke("trySoundBite", 2f);
                        break;
                    }

                    //mid score
                    if (Input.GetKeyUp(KeyCode.K))
                    {
                        anim.Play("kameel_running2", -1, 0);
                        position = gameObject.transform.position;
                        distance = gameSettingsObject.GetComponent<gameSettings>().midDistance;
                        target = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
                        playTriggerHit();
                        Invoke("trySoundBite", 2f);
                        break;
                    }

                    //low score
                    if (Input.GetKeyUp(KeyCode.L))
                    {
                        anim.Play("kameel_running2", -1, 0);
                        position = gameObject.transform.position;
                        distance = gameSettingsObject.GetComponent<gameSettings>().baseDistance;
                        target = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
                        playTriggerHit();
                        Invoke("trySoundBite", 2f);
                        break;
                    }
                    break;
            }



            // move sprite towards the target location
            if(transform.position.x < target.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, step);
            }
            else
            {
                anim.Play("kameel_idle_up",-1,0);
            }
            
            //check for winning position
            if (transform.position.x >= gameSettingsObject.GetComponent<gameSettings>().endPos)
            {
                gameSettingsObject.GetComponent<gameSettings>().triggerWin(player);
            }
        }
        else
        {
            //stop running animation when game ends
            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("kameel_running2"))
            {
                anim.Play("kameel_idle_up");
            }

            //get key inputs for game join
            if(gameSettingsObject.GetComponent<gameSettings>().canJoin == true && isPlaying == false)
            {
                //start button
                if (Input.GetKeyUp(KeyCode.F1) && player == 1)
                {
                    isPlaying = true;
                    anim.Play("kameel_getup");
                    target = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    firstTarget = true;
                    gameSettingsObject.GetComponent<AudioSource>().volume = gameSettingsObject.GetComponent<AudioSource>().volume / 4;
                    gameObject.GetComponent<AudioSource>().clip = gameSettingsObject.GetComponent<gameSettings>().a_join;
                    gameObject.GetComponent<AudioSource>().Play();
                    Invoke("resetMusicVolume", 1f);
                }
                //start button
                if (Input.GetKeyUp(KeyCode.F2) && player == 2)
                {
                    isPlaying = true;
                    anim.Play("kameel_getup");
                    target = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    firstTarget = true;
                    gameSettingsObject.GetComponent<AudioSource>().volume = gameSettingsObject.GetComponent<AudioSource>().volume / 4;
                    gameObject.GetComponent<AudioSource>().clip = gameSettingsObject.GetComponent<gameSettings>().a_join;
                    gameObject.GetComponent<AudioSource>().Play();
                    Invoke("resetMusicVolume", 1f);
                }
                //start button
                if (Input.GetKeyUp(KeyCode.F3) && player == 3)
                {
                    isPlaying = true;
                    anim.Play("kameel_getup");
                    target = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    firstTarget = true;
                    gameSettingsObject.GetComponent<AudioSource>().volume = gameSettingsObject.GetComponent<AudioSource>().volume / 4;
                    gameObject.GetComponent<AudioSource>().clip = gameSettingsObject.GetComponent<gameSettings>().a_join;
                    gameObject.GetComponent<AudioSource>().Play();
                    Invoke("resetMusicVolume", 1f);
                }
                //start button
                if (Input.GetKeyUp(KeyCode.F4) && player == 4)
                {
                    isPlaying = true;
                    anim.Play("kameel_getup");
                    target = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    firstTarget = true;
                    gameSettingsObject.GetComponent<AudioSource>().volume = gameSettingsObject.GetComponent<AudioSource>().volume / 2;
                    gameObject.GetComponent<AudioSource>().clip = gameSettingsObject.GetComponent<gameSettings>().a_join;
                    gameObject.GetComponent<AudioSource>().Play();
                    Invoke("resetMusicVolume", 1f);
                }
            }
        }
        
    }

    public void resetMusicVolume()
    {
        gameSettingsObject.GetComponent<AudioSource>().volume = gameSettingsObject.GetComponent<AudioSource>().volume * 4;
    }

    public void getDown()
    {
        //set base target, it will move to this position as long as the animation runs.
        target = transform.position;
        anim.Play("kameel_getdown", -1, 0);
    }

    public void trySoundBite()
    {
        int randnr = UnityEngine.Random.Range(1, 10);
        if (randnr == 5)
        {
            int soundbite = UnityEngine.Random.Range(1, 4);
            switch (soundbite)
            {
                case 1:
                    gameObject.GetComponent<AudioSource>().clip = gameSettingsObject.GetComponent<gameSettings>().a_kameel1;
                    gameObject.GetComponent<AudioSource>().Play();
                    break;
                case 2:
                    gameObject.GetComponent<AudioSource>().clip = gameSettingsObject.GetComponent<gameSettings>().a_kameel2;
                    gameObject.GetComponent<AudioSource>().Play();
                    break;
                case 3:
                    gameObject.GetComponent<AudioSource>().clip = gameSettingsObject.GetComponent<gameSettings>().a_kameel3;
                    gameObject.GetComponent<AudioSource>().Play();
                    break;
                case 4:
                    gameObject.GetComponent<AudioSource>().clip = gameSettingsObject.GetComponent<gameSettings>().a_kameel4;
                    gameObject.GetComponent<AudioSource>().Play();
                    break;
            }
        }
    }

    public void playTriggerHit()
    {
        gameObject.GetComponent<AudioSource>().clip = gameSettingsObject.GetComponent<gameSettings>().a_triggerHit;
        gameObject.GetComponent<AudioSource>().Play();
    }

}
