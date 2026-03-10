using UnityEngine;

public class PropellerSpinner : MonoBehaviour
{
    // プロペラが回転する速度
    public float rotationSpeed = 1000f;

    void Update()
    {
        // Z軸を中心に回転させる（モデルの向きによっては Vector3.forward 以外の場合もあります）
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}