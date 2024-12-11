using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI txtPoints1;
    [SerializeField] TextMeshProUGUI txtPoints2;

    int points1 = 0;
    int points2 = 0;

    public void AddPointP1() {
        points1++;
        txtPoints1.SetText(points1.ToString());
    }

    public void AddPointP2() {
        points2++;
        txtPoints1.SetText(points2.ToString());
    }


    

}
