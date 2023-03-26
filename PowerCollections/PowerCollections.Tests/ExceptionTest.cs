using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Wintellect.PowerCollections.Tests
{
	[TestClass]
	public class ExceptionTest
	{
		[TestMethod]
		public void ThrowException()
		{
			throw new Exception();
		}
	}
}