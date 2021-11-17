using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public GameObject player;

    void FixedUpdate()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        Vector3 newScale = healthBarImage.transform.localScale;
        newScale.x = Mathf.Clamp(player.GetComponent<Player_Components>().currentHitpoints / player.GetComponent<Player_Components>().maxHitpoints, 0, 1f);
        healthBarImage.transform.localScale = newScale;
    }
}