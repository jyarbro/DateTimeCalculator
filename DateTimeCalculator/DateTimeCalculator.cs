using System;
using System.Collections.Generic;

namespace DateTimeCalculator {
	/// <summary>
	/// Pre-calculates DateTime values based on string keys. Useful for implementing calculated fields where users input fixed string value to get variable dates.
	/// </summary>
	public class DateTimeCalculator {
		public Dictionary<string, DateTime> Functions { get; }

		public DateTimeCalculator() {
			Functions = new Dictionary<string, DateTime> {
				{ "ThisYear", ThisYear() },
				{ "NextYear", NextYear() },

				{ "ThisMonth", ThisMonth() },
				{ "NextMonth", NextMonth() },

				{ "NextSunday", NextDOW(DayOfWeek.Sunday) },
				{ "NextMonday", NextDOW(DayOfWeek.Monday) },
				{ "NextTuesday", NextDOW(DayOfWeek.Tuesday) },
				{ "NextWednesday", NextDOW(DayOfWeek.Wednesday) },
				{ "NextThursday", NextDOW(DayOfWeek.Thursday) },
				{ "NextFriday", NextDOW(DayOfWeek.Friday) },
				{ "NextSaturday", NextDOW(DayOfWeek.Saturday) },

				{ "PreviousSunday", PreviousDOW(DayOfWeek.Sunday) },
				{ "PreviousMonday", PreviousDOW(DayOfWeek.Monday) },
				{ "PreviousTuesday", PreviousDOW(DayOfWeek.Tuesday) },
				{ "PreviousWednesday", PreviousDOW(DayOfWeek.Wednesday) },
				{ "PreviousThursday", PreviousDOW(DayOfWeek.Thursday) },
				{ "PreviousFriday", PreviousDOW(DayOfWeek.Friday) },
				{ "PreviousSaturday", PreviousDOW(DayOfWeek.Saturday) },

				{ "NextFirstSunday", NextNthDOW(DayOfWeek.Sunday) },
				{ "NextFirstMonday", NextNthDOW(DayOfWeek.Monday) },
				{ "NextFirstTuesday", NextNthDOW(DayOfWeek.Tuesday) },
				{ "NextFirstWednesday", NextNthDOW(DayOfWeek.Wednesday) },
				{ "NextFirstThursday", NextNthDOW(DayOfWeek.Thursday) },
				{ "NextFirstFriday", NextNthDOW(DayOfWeek.Friday) },
				{ "NextFirstSaturday", NextNthDOW(DayOfWeek.Saturday) },

				{ "NextSecondSunday", NextNthDOW(DayOfWeek.Sunday, 1) },
				{ "NextSecondMonday", NextNthDOW(DayOfWeek.Monday, 1) },
				{ "NextSecondTuesday", NextNthDOW(DayOfWeek.Tuesday, 1) },
				{ "NextSecondWednesday", NextNthDOW(DayOfWeek.Wednesday, 1) },
				{ "NextSecondThursday", NextNthDOW(DayOfWeek.Thursday, 1) },
				{ "NextSecondFriday", NextNthDOW(DayOfWeek.Friday, 1) },
				{ "NextSecondSaturday", NextNthDOW(DayOfWeek.Saturday, 1) },

				{ "NextThirdSunday", NextNthDOW(DayOfWeek.Sunday, 2) },
				{ "NextThirdMonday", NextNthDOW(DayOfWeek.Monday, 2) },
				{ "NextThirdTuesday", NextNthDOW(DayOfWeek.Tuesday, 2) },
				{ "NextThirdWednesday", NextNthDOW(DayOfWeek.Wednesday, 2) },
				{ "NextThirdThursday", NextNthDOW(DayOfWeek.Thursday, 2) },
				{ "NextThirdFriday", NextNthDOW(DayOfWeek.Friday, 2) },
				{ "NextThirdSaturday", NextNthDOW(DayOfWeek.Saturday, 2) },

				{ "NextFourthSunday", NextNthDOW(DayOfWeek.Sunday, 3) },
				{ "NextFourthMonday", NextNthDOW(DayOfWeek.Monday, 3) },
				{ "NextFourthTuesday", NextNthDOW(DayOfWeek.Tuesday, 3) },
				{ "NextFourthWednesday", NextNthDOW(DayOfWeek.Wednesday, 3) },
				{ "NextFourthThursday", NextNthDOW(DayOfWeek.Thursday, 3) },
				{ "NextFourthFriday", NextNthDOW(DayOfWeek.Friday, 3) },
				{ "NextFourthSaturday", NextNthDOW(DayOfWeek.Saturday, 3) },

				{ "NextFifthSunday", NextNthDOW(DayOfWeek.Sunday, 4) },
				{ "NextFifthMonday", NextNthDOW(DayOfWeek.Monday, 4) },
				{ "NextFifthTuesday", NextNthDOW(DayOfWeek.Tuesday, 4) },
				{ "NextFifthWednesday", NextNthDOW(DayOfWeek.Wednesday, 4) },
				{ "NextFifthThursday", NextNthDOW(DayOfWeek.Thursday, 4) },
				{ "NextFifthFriday", NextNthDOW(DayOfWeek.Friday, 4) },
				{ "NextFifthSaturday", NextNthDOW(DayOfWeek.Saturday, 4) },

				{ "NextLastSunday", NextLastDOW(DayOfWeek.Sunday) },
				{ "NextLastMonday", NextLastDOW(DayOfWeek.Monday) },
				{ "NextLastTuesday", NextLastDOW(DayOfWeek.Tuesday) },
				{ "NextLastWednesday", NextLastDOW(DayOfWeek.Wednesday) },
				{ "NextLastThursday", NextLastDOW(DayOfWeek.Thursday) },
				{ "NextLastFriday", NextLastDOW(DayOfWeek.Friday) },
				{ "NextLastSaturday", NextLastDOW(DayOfWeek.Saturday) },
			};
		}
		
		DateTime ThisYear() {
			return new DateTime(DateTime.Now.Year, 1, 1);
		}

		DateTime NextYear() {
			return ThisYear().AddYears(1);
		}

		DateTime ThisMonth() {
			return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
		}

		DateTime NextMonth() {
			return ThisMonth().AddMonths(1);
		}

		/// <summary>
		/// Returns the next occuring Nth DOW of a month (i.e. next fourth tuesday)
		/// </summary>
		DateTime NextNthDOW(DayOfWeek dayOfWeek, int weeksToAdd = 0) {
			if (weeksToAdd > 4)
				throw new ArgumentOutOfRangeException(nameof(weeksToAdd), "Cannot add more than 4 weeks.");

			var today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

			var monthBaseDate = new DateTime(today.Year, today.Month, 1);
			var nextDOW = NextDOWFromDate(dayOfWeek, monthBaseDate);
			var nextNthDOW = nextDOW.AddDays(7 * weeksToAdd);

			if (nextNthDOW < today)
				nextNthDOW.AddMonths(1);

			return nextNthDOW;
		}

		/// <summary>
		/// Returns the previous occuring DOW (i.e. previous tuesday)
		/// </summary>
		DateTime PreviousDOW(DayOfWeek dayOfWeek) {
			var previousDate = NextDOWFromDate(dayOfWeek, DateTime.Now).AddDays(-7);

			return new DateTime(previousDate.Year, previousDate.Month, previousDate.Day);
		}

		/// <summary>
		/// Returns the next occuring DOW (i.e. next tuesday)
		/// </summary>
		DateTime NextDOW(DayOfWeek dayOfWeek) {
			return NextDOWFromDate(dayOfWeek, DateTime.Now);
		}

		/// <summary>
		/// Returns the next occuring DOW from a base date (i.e. next tuesday from DateTime.Now)
		/// </summary>
		DateTime NextDOWFromDate(DayOfWeek dayOfWeek, DateTime baseDate) {
			var nextDate = baseDate.AddDays((dayOfWeek - baseDate.DayOfWeek + 7) % 7);

			return new DateTime(nextDate.Year, nextDate.Month, nextDate.Day);
		}

		/// <summary>
		/// Returns the next occuring last DOW from a base date (i.e. next occurrence of last tuesday of a month from DateTime.Now)
		/// </summary>
		DateTime NextLastDOW(DayOfWeek dayOfWeek) {
			var baseDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
			var nextDate = baseDate.AddDays((dayOfWeek - baseDate.DayOfWeek - 7) % 7);

			return new DateTime(nextDate.Year, nextDate.Month, nextDate.Day);
		}
	}
}