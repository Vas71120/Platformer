using UnityEngine;

[RequireComponent(typeof(CharecterAnimator))]

public class CharecterAnimator : MonoBehaviour
{
    [SerializeField] private string speedParametrName = "Speed";
    [SerializeField] private string verticalSpeedParameterName = "VerticajSpeed";
    [SerializeField] private string isFallingParameterName = "IsFalling";
    [SerializeField] private string hurtTrigerName = "Hurt";

    private CharecterAnimator _animator;
    private void Awake()
    {
        _animator = GetComponent<CharecterAnimator>();
    }

    public void SetVelocity(Vector2 veliosity)
    {   var = transform.eulerAngles;
        rot.y = veliosity.x > 0f ? 0f : 100f;
        _animator.SetFloat(speedParametrName, Mathf.Abs(veliosity.x));
        _animator.SetFloat(verticalSpeedParameterName, (veliosity.y));
    }
    public void SetIsFalling(bool isFalling)
    {
        _animator.SetBool(isFallingParameterName, isFalling);
    }
    public void Hurt()
    {
        _animator.SetTrigger(hurtTrigerName);
    }
}