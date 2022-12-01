using UnityEngine;

public class ImageParrallax : MonoBehaviour
{
    [SerializeField] private float _scrollTo;
    [SerializeField] private float _duration = 3f;
    [SerializeField] private AnimationCurve _parralaxCurve;
    private RectTransform _rectTrasform;
    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private float _elapsed;

    // Start is called before the first frame update
    void Start()
    {
        _rectTrasform = GetComponent<RectTransform>();
        _startPoint = _rectTrasform.anchoredPosition;
        _endPoint = new Vector2(_rectTrasform.anchoredPosition.x, _scrollTo);
    }

    // Update is called once per frame
    void Update()
    {
        if (_rectTrasform.anchoredPosition == _endPoint) {
            _elapsed = 0;
            _endPoint = new Vector2(_startPoint.x, _startPoint.y);
            _startPoint = _rectTrasform.anchoredPosition;
            return;
        }

        _elapsed += Time.deltaTime;
        float percentComplete = _elapsed / _duration;
        Vector2 newPositon = Vector2.Lerp(_startPoint, _endPoint, _parralaxCurve.Evaluate(percentComplete));
        _rectTrasform.anchoredPosition = newPositon;
    }
}
