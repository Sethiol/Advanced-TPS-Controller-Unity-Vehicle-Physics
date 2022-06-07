using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoWidget : MonoBehaviour
{
    public TMPro.TMP_Text ammoText;
    private void Start()
    {
        ammoText.text = "";
    }
    public void Refresh(int ammoCount, int maxammo, string weaponName)
    {
        if (weaponName == null) { ammoText.text = ""; return; }
        if(weaponName == "Axe") { ammoText.text = "Axe"; }
        else if (weaponName == "Knife") { ammoText.text = "Knife"; }
        else
        {
            ammoText.text = weaponName + " " + ammoCount.ToString() + "/" + maxammo.ToString();
        }
    }
}
