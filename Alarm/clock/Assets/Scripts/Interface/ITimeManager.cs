namespace AlarmClock
{
	public interface ITimeManager
	{
		void CheckAlarmTriggered();
		void IncrementAlarmHour();
		void IncrementAlarmMinute();
		void IncrementCurrentHour();
		void IncrementCurrentMinute();
		void SetAlarm(IAlarm alarm);
		void SetDisplay(IDisplay display);
		void SetModeManager(IModeManager modeManager);
		void ShowAlarmTime();
		void ShowCurrentTime();
		void Snooze();
	}
}