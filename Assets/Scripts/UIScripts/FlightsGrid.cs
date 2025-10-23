using UnityEngine;
using UnityEngine.UI;

public class FlightsGrid : MonoBehaviour
{
    [SerializeField] private FlightsDataArraySO flightsDataArraySO;
    [SerializeField] private GameObject flightFrame;

    private void Start()
    {
        foreach (var o in flightsDataArraySO.flightData)
        {
            Instantiate(flightFrame, gameObject.transform);
            flightFrame.transform.GetChild(0).GetComponent<Image>().sprite = o.flightSprite;
        }
    }
}
