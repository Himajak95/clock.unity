namespace AlarmClock
{
	public interface IClock
	{
		IButtonManager ButtonManager { get; }

		void Start();
	}
}