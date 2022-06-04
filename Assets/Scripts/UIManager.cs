using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text healthText;

    private void Awake()
    {
        Player.Instance.OnBeingDamaged += DisplayHealth;
    }

    private void DisplayHealth()
    {
        healthText.text = Player.Instance.health.ToString();
    }
}
