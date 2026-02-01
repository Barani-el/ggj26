using DG.Tweening;
using NUnit.Framework;
using System.ComponentModel;
using UnityEngine;

public class DiceMachine : MonoBehaviour
{
    public static DiceMachine instance;

    [SerializeField] Transform[] spinningDrums;
    public int[] results;

    [UnityEngine.Range(0,6)]
    public int totalFaces;
    public float spinDuration;
    public float angleOffset;
    [ContextMenu("TestSpin")]
    public void TestSpin() => SpinDrums();


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }
    public void SpinDrums()
    {
        for (int i = 0; i < spinningDrums.Length; i++)
        {
            int random = Random.Range(1, 7);
            StartSpin(random, spinningDrums[i]);
            results[i] = random;
        }
    }
    public void StartSpin(int result,Transform drum)
    {
       
        float anglePerFace = 360f / totalFaces;

       
        float targetAngle = (result - 1) * anglePerFace + angleOffset;

       
        drum.DOLocalRotate(new Vector3(targetAngle + (360f * 5f), 0, 0), spinDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.OutQuart)
            .OnComplete(() => {
                Vector3 currentRot = drum.localEulerAngles;
                currentRot.x %= 360f;
                drum.localEulerAngles = currentRot;

                Debug.Log("Zar durdu: " + result);
            });
    }
}
