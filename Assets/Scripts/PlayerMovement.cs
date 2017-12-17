using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject deathParticles;
    public int areaNum;

    private float maxSpeed = 20.0f;
    private Vector3 input;
    private Vector3 spawnPoint;
    
    // Use this for initialization
    void Start()
    {
        moveSpeed = 7.5f;
        spawnPoint = transform.position;
        areaNum = 1;
        //GameObject wc = GameObject.FindGameObjectWithTag("WorldControl");
        //Transform wct = wc.transform;
        //for (int i = 0; i < wct.childCount; i++)
        //{
        //    print(wct.GetChild(i));
        //}
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Goal")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.transform.tag == "Area")
        {
            int nextArea = other.transform.GetComponent<Area>().nextArea;
            loadArea(nextArea);
        }

        if(other.transform.tag == "DeathPlane")
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            transform.position = spawnPoint;
        }

        if(other.transform.tag == "Teleporter")
        {
            Teleport tp;
            tp = other.transform.GetComponent<Teleport>();
            print(tp.teleportSpot.transform.name);
            transform.position = tp.teleportSpot.transform.position;
        }
    }

    private void loadArea(int nArea)
    {
        GameObject wc = GameObject.FindGameObjectWithTag("WorldControl");
        Transform[] objs = new Transform[wc.transform.childCount];
        WorldCtrl ctrl = wc.GetComponent<WorldCtrl>();
        int numOfFog = ctrl.fog.Length - 1;
        int size = 0;
        for (int x = 0; x < wc.transform.childCount; x++)
            objs[x] = wc.transform.GetChild(x);
        for (int x = 0; x < wc.transform.childCount; x++)
            if (objs[x].transform.tag == "Fog")
                size++;
        GameObject[] fog = new GameObject[size];
        for (int i = 0; i <= size - 1; i++)
            fog[i] = objs[i].gameObject;
        GameObject f1;
        GameObject f2;
        if (fog[0].GetComponent<Fog>().areaNum == nArea)
            f1 = fog[0];
        else
            f1 = fog[1];
        if (fog[1].GetComponent<Fog>().areaNum == nArea)
            f2 = fog[0];
        else
            f2 = fog[1];
        f1.GetComponent<Fog>().active = false;
        print(f1.name + " " + f1.GetComponent<Fog>().active);
        f2.GetComponent<Fog>().active = true;
        print(f2.name + " " + f2.GetComponent<Fog>().active);
        transform.position = f1.transform.GetChild(1).transform.position;
        areaNum = f2.GetComponent<Fog>().areaNum;
    }
}