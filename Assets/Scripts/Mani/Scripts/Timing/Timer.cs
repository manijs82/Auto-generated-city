namespace Mani.Scripts.Timing
{
    public class Timer
    {
        private float _time;
        private readonly float _defaultValue;
        private readonly float _maxValue;
        private readonly float _speed;

        public float Time => _time;

        public Timer(float defaultValue, float maxValue, float speed)
        {
            _defaultValue = defaultValue;
            _maxValue = maxValue;
            _speed = speed;
            _time = defaultValue;
        }

        public float Tick(float tick)
        {
            if(_time > _maxValue) return _time;
            _time += tick * _speed;
            return _time;
        }

        public void ResetToZero() => _time = 0;

        public void ResetToDefault() => _time = _defaultValue;
    }
}
