using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sling : MonoBehaviour
{
    public GameObject prefBullet;
    public float velocityMult = 8f;

    public GameObject placeShot;
    public Vector3 ejectPos;
    public GameObject bullet;
    public bool clicked;
    private Rigidbody bulletRigidbody;
    private int count = 0;

    void Awake()
    {
        Transform placeShotTrans = transform.Find("PlaceShot");
        ejectPos = placeShotTrans.position;
    }


    void OnMouseDown()
    {
        clicked = true;
        bullet = Instantiate(prefBullet) as GameObject;
        bullet.transform.position = ejectPos;
        bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.isKinematic = true;
    }
    void Update()
    {
        if (!clicked) return;
        
            Vector3 mousePos2D = Input.mousePosition;
            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            Vector3 mouseDelta = mousePos3D - ejectPos;
            float maxMagnitude = this.GetComponent<SphereCollider>().radius;
            if (mouseDelta.magnitude > maxMagnitude)
            {
                mouseDelta.Normalize();
                mouseDelta *= maxMagnitude;
            }

            Vector3 projPos = ejectPos + mouseDelta;
            bullet.transform.position = projPos;
       
            if (Input.GetMouseButtonUp(0))
                {
                clicked = false;
                bulletRigidbody.isKinematic = false;
                bulletRigidbody.velocity = -mouseDelta * velocityMult;
                bullet = null;
                count++;
            }
        if (count == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
