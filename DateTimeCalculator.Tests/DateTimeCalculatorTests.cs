using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateTimeCalculator.Tests {
	[TestClass]
	public class DateTimeCalculatorTests {
		// YOU ARE EXPECTED TO MANUALLY SET THESE VALUES TO ENSURE ACCURACY.

		DateTime ThisYear { get; } = new DateTime(2016, 1, 1, 0, 0, 0);
		DateTime ThisMonth { get; } = new DateTime(2016, 12, 1, 0, 0, 0);
		DateTime NextYear { get; } = new DateTime(2017, 1, 1, 0, 0, 0);
		DateTime NextMonth { get; } = new DateTime(2017, 1, 1, 0, 0, 0);
		DateTime NextWednesday { get; } = new DateTime(2016, 12, 14, 0, 0, 0);
		DateTime NextThirdWednesday { get; } = new DateTime(2016, 12, 21, 0, 0, 0);
		DateTime NextLastWednesday { get; } = new DateTime(2016, 12, 28, 0, 0, 0);
		DateTime PreviousWednesday { get; } = new DateTime(2016, 12, 7, 0, 0, 0);

		DateTimeCalculator Calculator { get; } = new DateTimeCalculator();

		[TestMethod]
		public void CalculatorTest_ThisYear() {
			Assert.AreEqual(ThisYear, Calculator.Functions["ThisYear"]);
		}

		[TestMethod]
		public void CalculatorTest_ThisMonth() {
			Assert.AreEqual(ThisMonth, Calculator.Functions["ThisMonth"]);
		}

		[TestMethod]
		public void CalculatorTest_NextYear() {
			Assert.AreEqual(NextYear, Calculator.Functions["NextYear"]);
		}

		[TestMethod]
		public void CalculatorTest_NextMonth() {
			Assert.AreEqual(NextMonth, Calculator.Functions["NextMonth"]);
		}

		[TestMethod]
		public void CalculatorTest_NextWednesday() {
			Assert.AreEqual(NextWednesday, Calculator.Functions["NextWednesday"]);
		}

		[TestMethod]
		public void CalculatorTest_NextThirdWednesday() {
			Assert.AreEqual(NextThirdWednesday, Calculator.Functions["NextThirdWednesday"]);
		}

		[TestMethod]
		public void CalculatorTest_NextLastWednesday() {
			Assert.AreEqual(NextLastWednesday, Calculator.Functions["NextLastWednesday"]);
		}

		[TestMethod]
		public void CalculatorTest_PreviousWednesday() {
			Assert.AreEqual(PreviousWednesday, Calculator.Functions["PreviousWednesday"]);
		}
	}
}