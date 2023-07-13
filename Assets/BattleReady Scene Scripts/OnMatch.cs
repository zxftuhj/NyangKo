using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OnMatch : MonoBehaviour
{
    private Canvas collidedRenderer;
    private RectTransform rect;
    private Text text;
    private Text leadership;
    private Text leadershipC;
    private GameObject[] game;
    public string str;

    public static OnMatch instance;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Country"))
        {
            Transform gameob1 = collision.transform.GetChild(0);
            text = gameob1.GetComponent<Text>();
            Transform gameob2 = collision.transform.GetChild(1);
            leadership = gameob2.GetComponent<Text>();
            Transform gameob3 = collision.transform.GetChild(2);
            leadershipC = gameob3.GetComponent<Text>();
            collidedRenderer = collision.gameObject.GetComponent<Canvas>();
            if(collidedRenderer != null)
            {
                str = collision.name;
                collidedRenderer.sortingOrder = 2;
                rect = collision.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(391, 124);
                text.rectTransform.sizeDelta = new Vector2(284, 107);
                text.fontSize = 64;
                leadership.rectTransform.sizeDelta = new Vector2(136, 60);
                leadership.fontSize = 40;
                leadershipC.rectTransform.sizeDelta = new Vector2(102, 79);
                leadershipC.fontSize = 52;
                leadership.rectTransform.position = new Vector3(leadership.rectTransform.position.x, leadership.rectTransform.position.y - 14f, leadership.rectTransform.position.z);
                leadershipC.rectTransform.position = new Vector3(leadershipC.rectTransform.position.x, leadershipC.rectTransform.position.y - 14f, leadershipC.rectTransform.position.z);
            }
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        game = GameObject.FindGameObjectsWithTag("Country");
    }

    private void Update()
    {
        for (int i =0;i<game.Length; i++)
        {
            if (game[i].name != str)
            {
                collidedRenderer = game[i].gameObject.GetComponent<Canvas>();
                rect = game[i].GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(341, 100);
                Transform gameob1 = game[i].transform.GetChild(0);
                text = gameob1.GetComponent<Text>();
                Transform gameob2 = game[i].transform.GetChild(1);
                leadership = gameob2.GetComponent<Text>();
                Transform gameob3 = game[i].transform.GetChild(2);
                leadershipC = gameob3.GetComponent<Text>();
                text.rectTransform.sizeDelta = new Vector2(284, 107);
                text.fontSize = 53;
                leadership.rectTransform.sizeDelta = new Vector2(136, 60);
                leadership.fontSize = 33;
                leadership.rectTransform.sizeDelta = new Vector2(102, 79);
                leadershipC.fontSize = 40;
                collidedRenderer.sortingOrder = 1;
            }
        }
    }
}
