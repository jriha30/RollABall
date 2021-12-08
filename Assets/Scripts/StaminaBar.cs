using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    public Image staminaBarImage;
    public GameObject player;

    public float recoverRate;
    public float emptyRate;

    void FixedUpdate()
    {
        UpdateStaminaBar();
    }

    public void UpdateStaminaBar()
    {
        staminaBarImage.fillAmount = Mathf.Clamp(player.GetComponent<Player_Components>().currentStamina / player.GetComponent<Player_Components>().maxStamina, 0, 1f);
    }
}