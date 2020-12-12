using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    Vector3 posCheckPoint;
    Vector3 posCheckPointCam;
    GameObject player;
    GameObject cam;
    AudioManager am;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        am = GetComponent<AudioManager>();
        SceneManager.LoadScene(1);
        posCheckPoint = new Vector3(0.0f, 0.0f, 0.0f);
    }


    public void playSound(string s)
    {
        am.playSound(s);
    }
    public void startRope()
    {
        am.startRope();
    }

    public void stopRope()
    {
        am.stopRope();
    }

    public void playColli()
    {
        am.playColli();
    }

    public void setCheckPoint(Vector3 pos) {
        posCheckPoint = pos;
        posCheckPointCam = Camera.main.transform.position;
    }

    public void goCheckPoint() {
        player.transform.position = posCheckPoint;
        cam.transform.position = posCheckPointCam;
    }

    public void setPlayer(GameObject p) {
        player = p;
    }

    public void setCam(GameObject c) {
        cam = c;
    }

    public void nextLevel() {
        int i = SceneManager.GetActiveScene().buildIndex;
        am.nextLevel(i);
        SceneManager.LoadScene(i+1);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            goCheckPoint();
        }
    }
}
