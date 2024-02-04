using TMPro;
using UnityEngine;
using Unity.UI;

public class FireCounter : MonoBehaviour
{
    public TextMeshProUGUI UpperText;
    public TextMeshProUGUI text;
    public int TotalNumberofFire;
    int NumberofFire;
    public GameManager gamemanager;

    private void Start()
    {
        NumberofFire = TotalNumberofFire;
        text.text = NumberofFire + "/" + TotalNumberofFire;
    }

    public void ChangeNumberOfFires(int number)
    {
        NumberofFire += number;
        text.text = NumberofFire + "/" + TotalNumberofFire;
        if (NumberofFire == number){
            GameCompleted();
        }
    }

    public void GameCompleted()
    {
        text.text = "";
        UpperText.text = "Весь огонь потушен!";
        gamemanager.EndGameSequence();
    }
}
