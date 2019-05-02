using System;

namespace AlarmClock
{
	public sealed class TimeManager : ITimeManager
	{
		private IAlarm _alarm;
		private ITime _alarmTime;
		private ITime _currentTime;
		private IDisplay _display;
		private IModeManager _modeManager;
		private ITime _snoozeTime;

		public TimeManager()
		{
			int hour = DateTime.Now.Hour;
			int minute = DateTime.Now.Minute;
			_alarmTime = new Time(hour, minute);
			_currentTime = new Time(hour, minute);
			_snoozeTime = _alarmTime;
			_snoozeTime.AddOneMinute();
		}

		public void CheckAlarmTriggered()
		{
			if (_currentTime.Equate(_alarmTime) && _modeManager.GetMode() == Mode.ALARM_ON)
			{
				_alarm.On();
			}
			else
			{
				_alarm.Off();
			}
		}

		public void IncrementAlarmHour()
		{
			_alarmTime.IncrementHour();
			ShowAlarmTime();
		}

		public void IncrementAlarmMinute()
		{
			_alarmTime.IncrementMinute();
			ShowAlarmTime();
		}

		public void IncrementCurrentHour()
		{
			_currentTime.IncrementHour();
			ShowCurrentTime();
			CheckAlarmTriggered();
		}

		public void IncrementCurrentMinute()
		{
			_currentTime.IncrementMinute();
			if (_modeManager.GetMode() != Mode.SET_ALARM)
			{
				ShowCurrentTime();
				CheckAlarmTriggered();
			}
		}

		public void SetAlarm(IAlarm alarm)
		{
			_alarm = alarm;
		}

		public void SetDisplay(IDisplay display)
		{
			_display = display;
		}

		public void SetModeManager(IModeManager modeManager)
		{
			_modeManager = modeManager;
		}

		public void ShowAlarmTime()
		{
			_display.ShowHour(_alarmTime.GetHour());
			_display.ShowMinute(_alarmTime.GetMinute());
		}

		public void ShowCurrentTime()
		{
			_display.ShowHour(_currentTime.GetHour());
			_display.ShowMinute(_currentTime.GetMinute());
		}

		public void Snooze()
		{
			_alarmTime.AddOneMinute();
			CheckAlarmTriggered();
		}
	}
}