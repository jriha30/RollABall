using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public GameObject player;
    public Player_Components playerComp;

    void Start()
    {
        playerComp = player.GetComponent<Player_Components>();
    }

    void FixedUpdate()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        Vector3 newScale = healthBarImage.transform.localScale;
        newScale.x = Mathf.Clamp(playerComp.currentHitpoints / playerComp.maxHitpoints, 0, 1f);
        healthBarImage.transform.localScale = newScale;
    }
}