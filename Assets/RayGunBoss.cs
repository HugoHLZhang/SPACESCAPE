using System.Collections;
using UnityEngine;

public class RayGunBoss : MonoBehaviour
{
    [SerializeField] float _interval = 3f;
    float _time;

    public float shootRate;
    private float m_shootRateTimeStamp;
    private Animator animBoss;
    public GameObject m_shotPrefab;
    private Transform target;
    [SerializeField] GameObject WeaponsToShoot;
    RaycastHit hit;
    float range = 1000.0f;

    void Start()
    {
        _time = 0f;
        GetReferences();
    }

    private void GetReferences()
    {
        animBoss = GetComponentInParent<Animator>();
        target =  PlayerController.instance.transform;
    }


    void Update()
    {
        /*
         if (ItemHolder.Find("Gun(Clone)"))
         {

             _time += Time.deltaTime;
             while (_time >= _interval)
             {
                 shootRay();
                 _time -= _interval;
             }
             /*if (Input.GetMouseButton(0)) //&& (manager.currentlyEquipedItem == 2)

             {
                 if (Time.time > m_shootRateTimeStamp)
                 {
                     shootRay();
                     m_shootRateTimeStamp = Time.time + shootRate;
                 }
             }

         }
             */
    }

    void shootRay()
    {
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        if (Physics.Raycast(ray, out hit, range))
        {

            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position + new Vector3(0,2f,0), transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            
            GameObject.Destroy(laser, 2f);


        }
    }

}


   