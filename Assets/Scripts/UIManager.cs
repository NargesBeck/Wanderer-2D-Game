using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text healthText;

    [SerializeField]
    GameObject wonPanel;

    [SerializeField]
    GameObject lostPanel;

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<UIManager>();
            return instance;
        }
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Player.Instance.OnBeingDamaged += DisplayHealth;
    }

    private void DisplayHealth()
    {
        healthText.text = Player.Instance.health.ToString();
    }

    public void LevelEnded(bool playerWon)
    {
        if (playerWon)
            wonPanel.SetActive(true);
        else
            lostPanel.SetActive(true);
    }
}
