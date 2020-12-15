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
    Vector3 posFirstCamera;
    GameObject player;
    GameObject cam;
    AudioManager am;
    bool firstTimeInLevel;
    bool godMode;
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
        godMode = false;
        firstTimeInLevel = true;
        am = GetComponent<AudioManager>();
        SceneManager.LoadScene(1);
        posCheckPoint = new Vector3(0.0f, 0.0f, 0.0f);
        posCheckPointCam = new Vector3(0f, 0f, -10f);
    }
    public void levelVisTransition()
    {
        if (firstTimeInLevel)
        {
            cam = Camera.main.gameObject;
            StopCoroutine("startVisTransition");
            StartCoroutine("startVisTransition");
        }
    }

    IEnumerator startVisTransition()
    {
        cam.transform.position = posFirstCamera;
        Vector3 finalPos = new Vector3(0, 0, -10f);
        float speed = 0.1f;

        player.GetComponent<PlayerMoves>().enabled = false;
        player.GetComponent<PlayerAnimations>().enabled = false;

        yield return new WaitForSeconds(3f);

        player.GetComponent<PlayerMoves>().enabled = true;
        player.GetComponent<PlayerAnimations>().enabled = true;
        player.GetComponent<RaysManage>().enabled = true;

        while (Vector3.Distance(cam.transform.position, finalPos) > 0.001)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, finalPos, speed);
            yield return new WaitForSeconds(0.01f);
        }
        firstTimeInLevel = false;
        yield return null;
    }
    public void setFirstCameraPos(Vector3 pos)
    {
        posFirstCamera = pos;
    }
    public bool getFirstTimeInLevel()
    {
        return firstTimeInLevel;
    }
    public void stopMusic()
    {
        am.stopMusic();
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
        player.GetComponent<MeshRenderer>().enabled = true;
        player.GetComponent<PlayerMoves>().enabled = true;
        player.GetComponent<PlayerAnimations>().enabled = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        player.transform.position = posCheckPoint;
        cam.transform.position = posCheckPointCam;
    }

    public void setPlayer(GameObject p) {
        player = p;
    }

    public void setCam(GameObject c) {
        cam = c;
    }
    public void stopSound()
    {
        am.stopSound();
    }

    public Vector3 getCheckPointPosition()
    {
        return posCheckPoint;
    }
    public Vector3 getCamPosition()
    {
        return posCheckPointCam;
    }

    public void nextLevel() {
        firstTimeInLevel = true;
        posCheckPoint = Vector3.zero;
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
        if (Input.GetKeyDown(KeyCode.N)) {
            nextLevel();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (godMode) godMode = false;
            else if (!godMode) godMode = true;
            print(godMode);
        }
    }
    public bool getGodMode()
    {
        return godMode;
    }
}
