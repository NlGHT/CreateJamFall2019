using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject hp1;
    private Text hp1Text;

    public GameObject points1;
    private Text points1Text;

    public GameObject turret1;
    private Text turret1Text;

    public GameObject stam1;
    private Text stam1Text;


    public GameObject hp2;
    private Text hp2Text;

    public GameObject points2;
    private Text points2Text;

    public GameObject turret2;
    private Text turret2Text;

    public GameObject stam2;
    private Text stam2Text;


    public GameObject player1;
    private PlayerController pc1;
    private TurretInfo ti1;

    public GameObject player2;
    private PlayerController pc2;
    private TurretInfo ti2;


    // Start is called before the first frame update
    void Start()
    {
        hp1Text = hp1.GetComponent<Text>();
        points1Text = points1.GetComponent<Text>();
        turret1Text = turret1.GetComponent<Text>();
        stam1Text = stam1.GetComponent<Text>();

        hp2Text = hp2.GetComponent<Text>();
        points2Text = points2.GetComponent<Text>();
        turret2Text = turret2.GetComponent<Text>();
        stam2Text = stam2.GetComponent<Text>();


        pc1 = player1.GetComponent<PlayerController>();
        pc2 = player2.GetComponent<PlayerController>();

        

    }

    // Update is called once per frame
    void Update()
    {

        if (player1)
        {
            ti1 = player1.GetComponentInChildren<TurretInfo>();
            hp1Text.text = "" + pc1.hp;
            points1Text.text = "" + pc1.points;
            turret1Text.text = "" + ti1.getTurretName();
            stam1Text.text = "" + pc1.energy;
        }
        if (player2)
        {
            ti2 = player2.GetComponentInChildren<TurretInfo>();
            hp2Text.text = "" + pc2.hp;
            points2Text.text = "" + pc2.points;
            turret2Text.text = "" + ti2.getTurretName();
            stam2Text.text = "" + pc2.energy;
        }
        
    }
}
