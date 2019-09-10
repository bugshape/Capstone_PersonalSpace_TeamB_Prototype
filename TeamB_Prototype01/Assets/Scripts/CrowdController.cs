using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrowdController : MonoBehaviour
{

    private GameObject player;
    private Vector3 prevPlayerPos;
    private Vector3 newPlayerPos;
    public int rotationSpeed;
    public int moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        prevPlayerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        newPlayerPos = player.transform.position;
        if(newPlayerPos != prevPlayerPos)
        {
            Vector3 direction = newPlayerPos - transform.position;
            direction.y = 0.0f;
            double distance = Mathf.Sqrt(Mathf.Pow((direction.x - newPlayerPos.x), 2) + Mathf.Pow((direction.y - newPlayerPos.y), 2) + Mathf.Pow((direction.z - newPlayerPos.z), 2));
            
            if (direction != Vector3.zero)
            {

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(Vector3.right, direction), rotationSpeed * Time.deltaTime);
                transform.position += (newPlayerPos - transform.position).normalized * moveSpeed * Time.deltaTime;

            }
            else
            {
                Debug.Log("DISTANCE: " + distance);
                
            }
            prevPlayerPos = newPlayerPos;
            
        }
        
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
}
