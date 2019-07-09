using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotKeySlot : MonoBehaviour
{

    [SerializeField]
    private Image imageCooldown;
    [SerializeField]
    private float cooldown = 5;
    [SerializeField]
    private Text PosionAmountText;
    [SerializeField]
    private bool isRedPosion;
    public bool isCooldown;

    void Start()
    {

    }

    void Update()
    {
        Cooldown();
        PosionAmountText.text = "" + Inventory.instance.RedPosionAmount;
    }

    public void Cooldown()
    {
        //isCooldown = true;

        if (isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;
            if (imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0;
                isCooldown = false;

            }
        }

    }
}
