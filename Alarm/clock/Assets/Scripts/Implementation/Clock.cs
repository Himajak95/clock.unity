namespace AlarmClock
{
	public class Clock : IClock
	{
		private IAlarm _alarm;
		private IButtonManager _buttonManager;
		private IDisplay _display;
		private IModeManager _modeManager;
		private ITimeManager _timeManager;
		private ITimer _timer;

		public IButtonManager ButtonManager => _buttonManager;

		public Clock()
			: this(new Alarm(), new Display())
		{ }

		public Clock(IAlarm alarm, IDisplay display)
		{
			_alarm = alarm;
			_buttonManager = new ButtonManager();
			_display = display;
			_modeManager = new ModeManager();
			_timeManager = new TimeManager();
			_timer = new SixtySecondTimer();

			_buttonManager.SetModeManager(_modeManager);
			_buttonManager.SetTimeManager(_timeManager);

			_timeManager.SetAlarm(_alarm);
			_timeManager.SetDisplay(_display);
			_timeManager.SetModeManager(_modeManager);
			_timer.SetTimeManager(_timeManager);
		}

		public void Start()
		{
			_timer.Start();
			_timeManager.ShowCurrentTime();
		}
	}
}