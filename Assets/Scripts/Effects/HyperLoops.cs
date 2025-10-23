using UnityEngine;

public class HyperLoops : MonoBehaviour
{
    [Header("루프 파티클")]
    [SerializeField] private ParticleSystem ps;
    [Header("파티클 설정")]
    [SerializeField] private Gradient[] gradient;

    private void Start()
    {
        ParticleSystem.MainModule psMain = ps.main;
        Gradient g = gradient[Random.Range(0, gradient.Length)];
        var minMax = new ParticleSystem.MinMaxGradient(g)
        {
            mode = ParticleSystemGradientMode.RandomColor
        };
        psMain.startColor = minMax;
    }
}


