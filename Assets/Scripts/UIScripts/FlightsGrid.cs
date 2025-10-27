using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightsGrid : MonoBehaviour
{

    [SerializeField] private GameObject flightFrame;
    [SerializeField] private int gridCellCount;
    [SerializeField] private List<GameObject> flightsArray;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;

    public void Initialize()
    {
        foreach (var o in PlayerPickDataManager.Instance.flightsDataArraySO.flightData)
        {
            var frame=Instantiate(flightFrame, gameObject.transform);
            flightsArray.Add(frame);
            frame.transform.GetChild(0).GetComponent<Image>().sprite = o.flightSprite;
            frame.GetComponent<IGetSetter<FlightsDataSO>>().Set(o);
        }

        gridLayoutGroup.constraintCount = flightsArray.Count / gridCellCount;
    }
    public GameObject ReturnObj(int index)
    {
        if (index < flightsArray.Count && index >= 0)
        {
            return flightsArray[index];
        }
        return null;
    }

    public FlightsDataSO ReturnFlightData(int index)
    {
        return PlayerPickDataManager.Instance.flightsDataArraySO.flightData[index];
    }

    public int ReturnIndex(Vector2 pos, int index)
    {
        var origin = index;
        if (pos.x < 0)
        {
            index--;
        }
        else if (pos.x > 0)
        {
            index++;
        }
        else if (pos.y > 0)
        {
            index -= gridCellCount;
        }
        else if (pos.y < 0)
        {
            index += gridCellCount;
        }

        if (index >= 0 && index < flightsArray.Count)
        {
            return index;
        } 
        return origin;
    }
}
