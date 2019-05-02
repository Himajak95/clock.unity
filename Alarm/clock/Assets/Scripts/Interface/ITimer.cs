namespace AlarmClock
{
	public interface ITimer
	{
		void HandleTimeOut();
		void SetTimeManager(ITimeManager timeManager);
		void Start();
	}
}