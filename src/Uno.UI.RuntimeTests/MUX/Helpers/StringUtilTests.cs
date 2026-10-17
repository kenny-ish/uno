#if !WINAPPSDK
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.UI.Helpers.WinUI;

namespace Uno.UI.RuntimeTests.MUX.Helpers
{
	[TestClass]
	public class StringUtilTests
	{
		[TestMethod]
		public void When_StringUtil()
		{
			Validate_Formatting("test, icon", "%1!s!, icon", "test");
			Validate_Formatting("test, 42 items", "%1!s!, %2!u! items", "test", 42);
			Validate_Formatting("test, 42 test2", "%1!s!, %2!u! %3!s!", "test", 42, "test2");
			Validate_Formatting("test %, 42% test2", "%1!s!, %2!u!%% %3!s!", "test %", 42, "test2");
			Validate_Formatting("test, 42% test2", "%1!s!, %2!u!%% %3!s!", "test", 42, "test2");
		}

		[TestMethod]
		[GitHubWorkItem("https://github.com/unoplatform/uno/issues/25441")]
		public void When_StringUtil_Literal_Braces()
		{
			Validate_Formatting("{Unsaved} test", "{Unsaved} %1!s!", "test");
			Validate_Formatting("test {42}", "%1!s! {%2!u!}", "test", 42);
			Validate_Formatting("{{test}}", "{{%1!s!}}", "test");
			Validate_Formatting("{ 42 }", "{ %1!u! }", 42);
			Validate_Formatting("{}", "{}");
		}

		[TestMethod]
		[GitHubWorkItem("https://github.com/unoplatform/uno/issues/25441")]
		public void When_StringUtil_Missing_Argument()
		{
			Validate_Formatting("", "%1!s!, %2!u! items", "test");
		}

		private void Validate_Formatting(string expected, string format, params object[] args)
			=> Assert.AreEqual(expected, StringUtil.FormatString(format, args));
	}
}
#endif
