namespace AlarmClock
{
	public interface IModeManager
	{
		Mode GetMode();
		void SetMode(Mode mode);
	}
}