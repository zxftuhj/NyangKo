using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instanc = null;

    [SerializeField] private Text text;
    private static float maxLeaderShip = 100;
    private static float leaderShip = maxLeaderShip;
    private static float stageClearCount = 0;
    public float maxLeaderShipP
    {
        get
        {
           return maxLeaderShip;
        }
        set{
            maxLeaderShip += value;
        }
    }
    public float leaderShipP {
        get
        {
            return leaderShip;
        }
        set
        {
            leaderShip -= value;
        }
    }
    public float stageClear
    {
        get
        {
            return stageClearCount;
        }
        set
        {
            stageClearCount += value;
        }
    }
    private void Awake()
    {
        if (instanc == null)
        {
            instanc = this;
        }
        else
        {
            if (instanc != this)
                Destroy(this.gameObject);
        }
        if (text != null)
        {
            if (leaderShip == maxLeaderShip)
            {
                text.color = new Color(0 / 255f, 1f, 38 / 255f);
                text.text = leaderShip.ToString();
            }
            else if (leaderShip < maxLeaderShip)
            {
                text.text = leaderShip.ToString();
            }
        }
    }
}
