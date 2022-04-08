using System.Collections;
using UnityEngine;
using TMPro;
public class CheckColor : MonoBehaviour
{
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private MeshRenderer smoozi;
    [SerializeField] TextMeshProUGUI percentColorText;

    private const float _procentToWin = 90f;

    private Color Color2;
    private float precent;

    public void checkWinCondition()
    {
        if (precent >= _procentToWin)
        {
            StartCoroutine(delayToWin());
        }
        else
        {
            StartCoroutine(delayToLose());

        }

    }

    private IEnumerator delayToLose()
    {
        yield return new WaitForSeconds(1f);
        loseMenu.gameObject.SetActive(true);
    }
    private IEnumerator delayToWin()
    {
        yield return new WaitForSeconds(1f);
        winMenu.gameObject.SetActive(true);
    }

    public void percentUI()
    {
        Color2 = GetComponent<MeshRenderer>().material.color;
        precent = Mathf.Round(Mathf.Abs(divisionColor(smoozi.material.color, Color2) - 100));
        percentColorText.text = precent.ToString() + "%";
    }


    private float divisionColor(Color playerCreatedColor, Color levelGoalColor)
    {
        float distance;
        float distanceToCenterColor1;
        float result;
        distance = Mathf.Sqrt(Mathf.Pow((levelGoalColor.r - playerCreatedColor.r), 2f) + Mathf.Pow((levelGoalColor.g - playerCreatedColor.g), 2f) + Mathf.Pow((levelGoalColor.b - playerCreatedColor.b), 2f));
        distanceToCenterColor1 = Mathf.Sqrt(Mathf.Pow((playerCreatedColor.r), 2f) + Mathf.Pow((playerCreatedColor.g), 2f) + Mathf.Pow((playerCreatedColor.b), 2f));

        result = (100 * distance) / distanceToCenterColor1;

        return result;
    }
}
