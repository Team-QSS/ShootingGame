using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightsGrid : MonoBehaviour
{
    [SerializeField] private FlightsDataArraySO flightsDataArraySO;
    [SerializeField] private GameObject flightFrame;

    [SerializeField] private List<GameObject> flightsArray;

    private void Start()
    {
        foreach (var o in flightsDataArraySO.flightData)
        {
            var frame=Instantiate(flightFrame, gameObject.transform);
            flightsArray.Add(frame);
            frame.transform.GetChild(0).GetComponent<Image>().sprite = o.flightSprite;
            frame.GetComponent<IGetSetter<FlightsDataSO>>().Set(o);
        }
    }
}
