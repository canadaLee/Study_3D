using UnityEngine;
using System.Collections;

public class BombSpanwer : MonoBehaviour
{
    public GameObject bombPrefab;

    public int rangeX = 5;
    public int rangeZ = 5;

    IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);

            RespawnBomb();
        }
    }

    private void RespawnBomb()
    {
        float ranX = Random.Range(-rangeX, rangeZ + 1);
        float ranZ = Random.Range(-rangeX, rangeZ + 1);

        Vector3 ranPos = new Vector3(ranX, 10f, ranZ);

        Instantiate(bombPrefab, ranPos, Quaternion.identity);
    }

}
