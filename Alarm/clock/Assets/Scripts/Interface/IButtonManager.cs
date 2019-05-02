namespace AlarmClock
{
	public interface IButtonManager
	{
		void DoAlarmOff();
		void DoAlarmOn();
		void DoIncrementHour();
	 	void DoIncrementMinute();
		void DoSetAlarm();
		void DoSetTime();
		void DoSnooze();
		void SetModeManager(IModeManager modeManager);
		void SetTimeManager(ITimeManager timeManager);
	}
}