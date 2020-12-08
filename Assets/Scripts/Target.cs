using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    
    static public bool purpose = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Target.purpose = true;
            Material mat = GetComponent<Renderer>().material;
            Color alfa = mat.color;
            alfa.a = 1;
            mat.color = alfa;

            if (SceneManager.GetActiveScene().buildIndex == Level.Levels)
            { 
                Level.Levels++;
            }
            Task.Delay(1000).Wait();
            SceneManager.LoadScene(5);
        
    }
    }


    



}
