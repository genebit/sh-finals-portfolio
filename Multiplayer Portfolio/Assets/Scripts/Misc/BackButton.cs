using UnityEngine.SceneManagement;
using UnityEngine;

namespace Scripts.Misc 
{
    public class BackButton : MonoBehaviour
    {
        public void ReturnHome() 
        {
            // Return to Login
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }   
    }
}
