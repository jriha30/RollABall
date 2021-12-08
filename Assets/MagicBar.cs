using UnityEngine;
using UnityEngine.UI;
public class MagicBar : MonoBehaviour
{
    public Image magicBarImage;
    public RectTransform magicBar;
    public GameObject player;
    public Player_Components playerComp;

    public float recoverRate;

    void Start()
    {
        playerComp = player.GetComponent<Player_Components>();
        magicBar = magicBarImage.GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        UpdateMagicBar();
    }

    public void UpdateMagicBar()
    {
        Vector3 newScale = magicBarImage.transform.localScale;
        newScale.y = Mathf.Clamp(playerComp.currentMagic / playerComp.maxMagic, 0, 1f);
        magicBar.localPosition = new Vector3(magicBar.localPosition.x, (playerComp.currentMagic - playerComp.maxMagic) / 2, magicBar.localPosition.z);
        magicBarImage.transform.localScale = newScale;
    }
}