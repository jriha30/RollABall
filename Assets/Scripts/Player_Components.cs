using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Components : MonoBehaviour
{
    public GameObject currentRoom;
    public int maxHitpoints;
    public float currentHitpoints;

    public float armorClass;

    public HealthBar healthBar;
    public StaminaBar staminaBar;
    public MagicBar magicBar;

    public int maxStamina;
    public float currentStamina;

    public int maxMagic;
    public float currentMagic;

    public static bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentRoom = Get_Room.currentRoom;
        currentHitpoints = maxHitpoints;
        currentStamina = maxStamina;
        currentMagic = maxMagic;
    }
}
