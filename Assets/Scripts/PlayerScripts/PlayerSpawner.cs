using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] players;
    public void Start()
    {
        for (int i = 0; i < players.Length; i++)
        {
            
            if (PlayerPickDataManager.Instance.flightsDataArraySO != null)
            {
                var data = PlayerPickDataManager.Instance.GetFlightDataByIndex(i);
                players[i].GetComponent<SpriteRenderer>().sprite =data.flightSprite;
                players[i].GetComponent<PlayerStatus>().ChangeFlightStat(data.flightDataSO);
            }
            players[i].SetActive(true);
        }
    }
}
