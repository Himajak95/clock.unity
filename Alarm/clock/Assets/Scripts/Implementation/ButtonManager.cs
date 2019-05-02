namespace AlarmClock
{
	public sealed class ButtonManager : IButtonManager
	{
		private IModeManager _modeManager;
		private ITimeManager _timeManager;

		public void DoAlarmOff()
		{
			_modeManager.SetMode(Mode.ALARM_OFF);
			_timeManager.CheckAlarmTriggered();
		}

		public void DoAlarmOn()
		{
			_modeManager.SetMode(Mode.ALARM_ON);
			_timeManager.CheckAlarmTriggered();
		}

		public void DoIncrementHour()
		{
			Mode currentMode = _modeManager.GetMode();
			if (currentMode == Mode.SET_ALARM)
			{
				_timeManager.IncrementAlarmHour();
			}
			else if (currentMode != Mode.SET_ALARM)
			{
				_timeManager.IncrementCurrentHour();
			}
		}

		public void DoIncrementMinute()
		{
			Mode currentMode = _modeManager.GetMode();
			if (currentMode == Mode.SET_ALARM)
			{
				_timeManager.IncrementAlarmMinute();
			}
			else if (currentMode != Mode.SET_ALARM)
			{
				_timeManager.IncrementCurrentMinute();
			}
		}

		public void DoSetAlarm()
		{
			_modeManager.SetMode(Mode.SET_ALARM);
			_timeManager.ShowAlarmTime();
		}

		public void DoSetTime()
		{
			_modeManager.SetMode(Mode.SET_TIME);
			_timeManager.ShowCurrentTime();
		}

		public void DoSnooze()
		{
			_timeManager.Snooze();
		}

		public void SetModeManager(IModeManager modeManager)
		{
			_modeManager = modeManager;
		}

		public void SetTimeManager(ITimeManager timeManager)
		{
			_timeManager = timeManager;
		}
	}
}