using System.Timers;

namespace AlarmClock
{
	public sealed class SixtySecondTimer : ITimer
	{
		private ITimeManager _timeManager;

		private Timer _timer;

		public SixtySecondTimer()
		{
			_timer = new Timer(60000);
			_timer.Elapsed += (s, e) =>
			{
				HandleTimeOut();
			};
		}

		public void HandleTimeOut()
		{
			_timeManager.IncrementCurrentMinute();
		}

		public void SetTimeManager(ITimeManager timeManager)
		{
			_timeManager = timeManager;
		}

		public void Start()
		{
			_timer.Start();
		}
	}
}