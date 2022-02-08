using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Collided with a friendly object");
                break;
            case "Finish":
                Debug.Log("Collided with finish location");
                break;
            case "Fuel":
                Debug.Log("Collided with a fuel object");
                break;
            default:
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex);            
    }
}