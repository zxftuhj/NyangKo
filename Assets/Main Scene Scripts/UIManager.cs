using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Image rightdoor;
    [SerializeField] private Image leftdoor;
    [SerializeField] private Button startButton;
    [SerializeField] private Button powerUpButton;
    [SerializeField] private Image TextMessage;
    [SerializeField] private Image Mascot;
    [SerializeField] private Button CopyBtn1;
    [SerializeField] private Button CopyBtn2;
    [SerializeField] private Image CopyDoor1;
    [SerializeField] private Image CopyDoor2;
    [SerializeField] private Text catCamp;
    [SerializeField] private Text CatCamp2;
    [SerializeField] private Text CopyCatCamp;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private GameObject gameob;
    private Canvas collidedRenderer1;
    private bool istrue = false;
    private bool istrue2 = true;
    public float jumpPower;
    private Canvas collidedRenderer2;
    private string str = "����� ������ �� �� ȯ����! �Ŀ� �� ȭ�鿡�� ���ο� ĳ���͸� ȹ���ϴ°Ŵٳ�";
    private string[] arr = new string[] { "������ ���� ������ ������ �������� ȥ���ٳ�!", "���ݷ� �ٿ� ��ų�� �����ų� ü���� ��� ������ �� �ִ� ������ �ִ� �� ���ٳ�", "'���ڴ��' �� Ž���� �� �߱� �������� �߰��ϱ� ���� ����Ʈ ���ִ� ĳ���ʹٳ�", "��� ���� �� �� ��. ����ġ�� ���� �� �����ĵ� ��. ����̶� �׷��� ���� ������ �ƴϴϱ�", "�������� ���� �׸��� �ڴ� ��ħ�� �� �ް� ��ư��� ���̴ٳ�", "������ ������ ������ �� �� ���ٳ�", "������ Ī�������� ��۰Ŵٳ� �������� ����ϴ� ����� �ڶ������� �������� ���ٳ�" };
    Vector3 vec = new Vector3();
    Vector3 Battlevec = new Vector3();
    Vector3 PowerUpvec = new Vector3();
    Vector3 Mascotvec = new Vector3();
    Vector3 rdoorvec = new Vector3();
    Vector3 ldoorvec = new Vector3();
    private Canvas collidedRenderer;
    private RectTransform rect;
    private Text textCountry;
    private Text leadership;
    private Text leadershipC;
    private int n;
    void Awake()
    {
        vec = catCamp.transform.position;
        Battlevec = startButton.transform.position;
        PowerUpvec = powerUpButton.transform.position;
        Mascotvec = Mascot.transform.position;
        rdoorvec = rightdoor.transform.position;
        ldoorvec = leftdoor.transform.position;
        text.text = str;
        istrue2 = true;
        collidedRenderer1 = rightdoor.gameObject.GetComponent<Canvas>();
        collidedRenderer2 = leftdoor.gameObject.GetComponent<Canvas>();
    }

    void Update()
    {
        if (istrue)
        {
            NextScene();
        }
    }
    IEnumerator terpCoroutine()
    {
        while (true)
        {
            powerUpButton.transform.position = Vector3.MoveTowards(powerUpButton.transform.position, CopyBtn2.transform.position, 6f);
            yield return new WaitForSeconds(0.1f);
            startButton.transform.position = Vector3.MoveTowards(startButton.transform.position, CopyBtn1.transform.position, 6f);
            TextMessage.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            Jumpfun();
            yield return new WaitForSeconds(0.7f);
            collidedRenderer1.overrideSorting = true;
            collidedRenderer1.sortingOrder = 3;
            collidedRenderer2.overrideSorting = true;
            collidedRenderer2.sortingOrder = 3;
            CenterCountry();
            catCamp.transform.position = Vector3.MoveTowards(catCamp.transform.position, CopyCatCamp.transform.position, 6f);
            leftdoor.transform.position = Vector3.MoveTowards(leftdoor.transform.position, CopyDoor1.transform.position, 6f);
            rightdoor.transform.position = Vector3.MoveTowards(rightdoor.transform.position, CopyDoor2.transform.position, 6f);
            yield return new WaitForSeconds(0.1f);
            CatCamp2.transform.position = Vector3.MoveTowards(CatCamp2.transform.position, vec, 11f);
            yield return new WaitForSeconds(0.8f);
            SceneManager.LoadScene("BattleReady");
            istrue = false;
        }
    }
    private void CenterCountry()
    {
        GameObject[] gameObs = GameObject.FindGameObjectsWithTag("Country");
        n = ScrollViews.instance.countryClearCountP;
        Transform gameob1 = gameObs[n].transform.GetChild(0);
        textCountry = gameob1.GetComponent<Text>();
        Transform gameob2 = gameObs[n].transform.GetChild(1);
        leadership = gameob2.GetComponent<Text>();
        Transform gameob3 = gameObs[n].transform.GetChild(2);
        leadershipC = gameob3.GetComponent<Text>();
        collidedRenderer = gameObs[n].gameObject.GetComponent<Canvas>();
        if (collidedRenderer != null)
        {
            collidedRenderer.sortingOrder = 2;
            rect = gameObs[n].GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(232, 76);
            textCountry.fontSize = 40;
            leadership.fontSize = 21;
            leadershipC.fontSize = 30;
        }
    }
    private void Jumpfun()
    {
        if (istrue2)
        {
            gameob.GetComponent<BoxCollider2D>().enabled = false;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            istrue2 = false;
        }
    }
    public void NextScene()
    {
        istrue = true;
        if (istrue)
        {
            StartCoroutine("terpCoroutine");
        }
    }
    
    public void TextClick()
    {
        int num = Random.Range(0, arr.Length);
        text.text = arr[num];
    }
}
