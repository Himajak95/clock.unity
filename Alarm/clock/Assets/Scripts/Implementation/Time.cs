namespace AlarmClock
{
	public sealed class Time : ITime
	{
		private int _hour;
		private int _minute;

		public Time(int hour, int minute)
		{
			_hour = hour;
			_minute = minute;
		}

		public void AddOneMinute()
		{
			IncrementMinute();
		}

		public bool Equate(ITime time)
		{
			return time.GetHour() == GetHour() && time.GetMinute() == GetMinute();
		}

		public int GetHour()
		{
			return _hour;
		}

		public int GetMinute()
		{
			return _minute;
		}

		public void IncrementHour()
		{
			_hour += 1;
			if (_hour >= 24)
			{
				_hour = 0;
			}
		}

		public void IncrementMinute()
		{
			_minute += 1;
			if(_minute >= 60)
			{
				_minute = 0;
				IncrementHour();
			}
		}
	}
}