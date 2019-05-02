namespace AlarmClock
{
	public interface ITime
	{
		void AddOneMinute();
		bool Equate(ITime time);
		int GetHour();
		int GetMinute();
		void IncrementHour();
		void IncrementMinute();
	}
}