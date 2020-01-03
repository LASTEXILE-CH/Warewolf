/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Data.Decisions.Operations;
using NUnit.Framework;

namespace Dev2.Data.Tests.DecisionsTests.Operations
{
    /// <summary>
    /// Is Not Binary Decision
    /// </summary>
    [TestFixture]
    public class IsNotBinaryTests
    {
        [Test]
        [Author("Pieter Terblanche")]
        [Category(nameof(IsNotBinary))]
        public void IsNotBinary_Invoke_ItemsEqual_ReturnsFalse()
        {
            //------------Setup for test--------------------------
            var endsWith = new IsNotBinary();
            var cols = new string[2];
            cols[0] = "101010";
            //------------Execute Test---------------------------
            var result = endsWith.Invoke(cols);
            //------------Assert Results-------------------------
            Assert.IsFalse(result);
        }

        [Test]
        [Author("Pieter Terblanche")]
        [Category(nameof(IsNotBinary))]
        public void IsNotBinary_Invoke_NotEqualItems_ReturnsTrue()
        {
            //------------Setup for test--------------------------
            var endsWith = new IsNotBinary();
            var cols = new string[2];
            cols[0] = "aaa1";
            //------------Execute Test---------------------------
            var result = endsWith.Invoke(cols);
            //------------Assert Results-------------------------
            Assert.IsTrue(result);
        }

        [Test]
        [Author("Pieter Terblanche")]
        [Category(nameof(IsNotBinary))]
        public void IsNotBinary_Invoke_EmptyColumns_ReturnsFalse()
        {
            //------------Setup for test--------------------------
            var endsWith = new IsNotBinary();
            var cols = new string[1];
            cols[0] = null;
            //------------Execute Test---------------------------
            var result = endsWith.Invoke(cols);
            //------------Assert Results-------------------------
            Assert.IsFalse(result);
        }

        [Test]
        [Author("Pieter Terblanche")]
        [Category(nameof(IsNotBinary))]
        public void IsNotBinary_HandlesType_ReturnsIsEndsWithType()
        {
            var expected = enDecisionType.IsNotBinary;
            //------------Setup for test--------------------------
            var isEndsWith = new IsNotBinary();
            //------------Execute Test---------------------------
            //------------Assert Results-------------------------
            Assert.AreEqual(expected, isEndsWith.HandlesType());
        }
    }
}
