using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace UIScripts
{
    public class BarUI : MonoBehaviour
    {
        [Header("HUD바 설정")]
        [SerializeField] private GameObject barObj;
        [SerializeField] private Color barColor;
        private List<GameObject> _barObjs = new();

        public void OnDrawBar(int current, int max)
        {
            if (current > _barObjs.Count)
            {
                for (int i = _barObjs.Count; i < current; i++)
                {
                    var o = ObjectPoolManager.Instance.Get(barObj, transform);
                    o.gameObject.GetComponent<BarPart>().SetColor(barColor);
                    _barObjs.Add(o);
                }
            }
            else if (current < _barObjs.Count)
            {
                for (int i = _barObjs.Count - 1; i >= current; i--)
                {
                    ObjectPoolManager.Instance.Return(_barObjs[i]);
                    _barObjs.RemoveAt(i);
                }
            }
        }
    }
}