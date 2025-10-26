using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickDescriptionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI shipName;
    [SerializeField] private Image shipImage;
    [SerializeField] private TextMeshProUGUI description;

    public event Func<int> getIndex;
    public event Func<int,FlightsDataSO> getFlightsData;

    public void OnUpdateUI()
    {
        var flightsDataSo =getFlightsData?.Invoke(getIndex?.Invoke() ?? 0);
        shipName.text = flightsDataSo.flightName;
        shipImage.sprite = flightsDataSo.flightSprite;
        description.text = flightsDataSo.flightDescription;
    }
}
