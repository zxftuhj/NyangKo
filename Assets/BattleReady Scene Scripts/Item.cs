using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Button Lock;
    [SerializeField] private Button snip;
    [SerializeField] private Button computer;
    [SerializeField] private Button storage;
    [SerializeField] private Button treasure;
    [SerializeField] private Button speed;
    private bool isClick = false;
    private bool isClick2 = false;
    private bool isClick3 = false;
    private bool isClick4 = false;
    private bool isClick5 = false;
    private bool isClick6 = false;
    public void LockClick()
    {
        if (!isClick)
        {
            Lock.image.color = new Color(197 / 255f, 133 / 255f, 0f);
            isClick = true;
        }
        else
        {
            Lock.image.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            isClick = false;
        }
    }
    public void Sniping()
    {
        if (!isClick2)
        {
            snip.image.color = new Color(169 / 255f, 59 / 255f, 232 / 255f);
            isClick2 = true;
        }
        else
        {
            snip.image.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            isClick2 = false;
        }
    }
    public void Computer()
    {
        if (!isClick3)
        {
            computer.image.color = new Color(171 / 255f, 171 / 255f, 171 / 255f);
            isClick3 = true;
        }
        else
        {
            computer.image.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            isClick3 = false;
        }
    }
    public void Storage()
    {
        if (!isClick4)
        {
            storage.image.color = new Color(246 / 255f, 247 / 255f, 21 / 255f);
            isClick4 = true;
        }
        else
        {
            storage.image.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            isClick4 = false;
        }
    }
    public void Treasure()
    {
        if (!isClick5)
        {
            treasure.image.color = new Color(202 / 255f, 160 / 255f, 0f);
            isClick5 = true;
        }
        else
        {
            treasure.image.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            isClick5 = false;
        }
    }
    public void Speed()
    {
        if (!isClick6)
        {
            speed.image.color = new Color(197 / 255f, 242 / 255f, 72 / 255f);
            isClick6 = true;
        }
        else
        {
            speed.image.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            isClick6 = false;
        }
    }
}
