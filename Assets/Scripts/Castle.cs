using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Castle : MonoBehaviour
{
    [SerializeField] int lives = 100;
    [SerializeField] TMP_Text liveText;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
        lives -= enemy.damage;
        Destroy(other.gameObject);
        liveText.text = "Lives: " + lives.ToString();
        if(lives <= 0 )
        {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        }
    }
}
