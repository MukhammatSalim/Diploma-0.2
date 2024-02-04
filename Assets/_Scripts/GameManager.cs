using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public enum GameState
{
    Fire,
    Earthquake,
    TA
}
public class GameManager : MonoBehaviour
{
    public GameState CurrentGameState;
    public AudioSource AudioSource;
    public TextMeshProUGUI UpperText;
    public TextMeshProUGUI text;
    private int TotalNumberofFire = 0;
    int NumberofFire;
    public List<GameObject> FireList = new List<GameObject>();
    public GameObject[] FallingObj;
    private bool _next;
    public ScreenShakeVR MainCameraShaker;


    private void Awake() {
        MainCameraShaker = GameObject.Find("Main Camera").GetComponent<ScreenShakeVR>();
    }
    private void Start()
    {
        switch (CurrentGameState)
        {
            case GameState.Fire:
                {
                    foreach (GameObject fire in FireList)
                    {
                        TotalNumberofFire += 1;
                    }
                    StartCoroutine(FireStarter());
                    NumberofFire = 0;
                    text.text = NumberofFire + "/" + TotalNumberofFire;
                    break;
                }
            case GameState.Earthquake:{
                FallingObj = GameObject.FindGameObjectsWithTag("RoomObjs");
                StartCoroutine(Earthquake());
                break;
            }
            
        }
    }
    public void EndGameSequence()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameCompleted");

    }


    public void ChangeNumberOfFires()
    {
        NumberofFire += 1;
        text.text = NumberofFire + "/" + TotalNumberofFire;
        if (NumberofFire == TotalNumberofFire)
        {
            GameCompleted();
        }
    }

    public void GameCompleted()
    {
        text.text = "";
        UpperText.text = "Весь огонь потушен!";
        EndGameSequence();
    }

    public void ChangeScene(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    IEnumerator FireStarter()
    {
        Debug.Log("FireSpreading!");
        for (int a = 0; a < TotalNumberofFire; a++)
        {
            _next = false;
            while (_next == false)
            {
                var b = GetRandomFire();
                Debug.Log("New attempt to brun");
                if (FireList[b].activeSelf == false)
                {
                    FireList[b].SetActive(true);
                    _next = true;
                    Debug.Log("Successful burning");
                    yield return new WaitForSeconds(5);
                }
            }
        }
    }
    public int GetRandomFire()
    {
        int x = Random.Range(0, TotalNumberofFire);
        Debug.Log("Got New Fire");
        return x;
    }

    IEnumerator Earthquake()
    {
        MainCameraShaker.Shake(1, 5, 3);
        yield return new WaitForSeconds(1);
    }

}
