using System.Collections;
using UnityEngine;
using UnityEngine.Splines;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float spawnTime = 1.0f;
    [SerializeField] SplineContainer splineContainer;
    [SerializeField] Coins coins;
    [SerializeField] public int spawnCount = 10;
    int wave=0;
    [SerializeField] TMP_Text waveText;
    public void StartSpawn()
    {
        wave++;
        if(waveText) waveText.text = "Waves: " + wave.ToString();
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn(){
        for(int i = 0; i < spawnCount; i++){
            GameObject obj = Instantiate(prefab, transform);
            obj.GetComponent<Enemy>().coins = coins;
            obj.GetComponent<SplineAnimate>().Container = splineContainer;
            yield return new WaitForSeconds(spawnTime);
        }
        spawnCount += 1;
    }
}
