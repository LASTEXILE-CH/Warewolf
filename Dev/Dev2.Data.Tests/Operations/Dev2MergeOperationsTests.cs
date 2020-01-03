/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using Dev2.Data.Interfaces;
using Dev2.Data.Operations;
using NUnit.Framework;
using Warewolf.UnitTestAttributes;


namespace Dev2.Data.Tests.Operations
{
    [TestFixture]
    public class Dev2MergeOperationsTests
    {
        IDev2MergeOperations _mergeOperations;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [OneTimeSetUp]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [SetUp]
        public void MyTestInitialize()
        {
            _mergeOperations = new Dev2MergeOperations();
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #region Index Tests

        [Test]
        public void Merge_Index_Merge_Left_Padding_Pad_Five_Chars_Expected_Successful_Merge()
        {
            _mergeOperations.Merge(@"TestData!!", "Index", "15", "0", "Left");
            Assert.AreEqual("TestData!!00000", _mergeOperations.MergeData.ToString());
        }

        [Test]
        public void Merge_Index_Merge_Right_Padding_Pad_Five_Chars_Expected_Successful_Merge()
        {
            _mergeOperations.Merge(@"TestData!!", "Index", "15", "0", "Right");
            Assert.AreEqual("00000TestData!!", _mergeOperations.MergeData.ToString());
        }

        [Test]
        public void Merge_Index_Merge_Right_Padding_Remove_Five_Chars_Expected_Successful_Merge()
        {
            _mergeOperations.Merge(@"TestData!!", "Index", "5", "0", "Right");
            Assert.AreEqual("TestD", _mergeOperations.MergeData.ToString());
        }

        [Test]
        public void Merge_Index_Merge_Left_Padding_Remove_Five_Chars_Expected_Successful_Merge()
        {
            _mergeOperations.Merge(@"TestData!!", "Index", "5", "0", "Left");
            Assert.AreEqual("TestD", _mergeOperations.MergeData.ToString());
        }

        #endregion

        #region Tab Tests

        [Test]
        public void Merge_Tab_Merge_Expected_Successful_Merge()
        {
            _mergeOperations.Merge(@"TestData!!", "Tab", "", "", "Left");
            Assert.AreEqual("TestData!!	", _mergeOperations.MergeData.ToString());
        }

        #endregion

        #region Chars Tests

        [Test]
        public void Merge_Chars_Merge_Expected_Successful_Merge()
        {
            _mergeOperations.Merge(@"TestData!!", "Chars", " wow amazing test data:)", "", "Left");
            Assert.AreEqual("TestData!! wow amazing test data:)", _mergeOperations.MergeData.ToString());
        }

        #endregion

        #region New Line Tests

        [Test]
        public void Merge_New_Line_Merge_Expected_Successful_Merge()
        {
            _mergeOperations.Merge(@"TestData!!", "New Line", "", "", "Left");
            const string expected = "TestData!!";
            Assert.AreEqual(expected, _mergeOperations.MergeData.ToString().Trim());
        }

        #endregion

        #region Negative Tests

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Merge_Chars_Merge_With_Null_Value_Expected_Successful_Merge()
        {
            _mergeOperations.Merge(null, "Chars", "", "", "Left");
        }

        #endregion
    }
}
