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
using System.Activities;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Common.Interfaces.Enums;
using Dev2.Runtime.ESB.Management.Services;
using Dev2.Runtime.Hosting;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Workspaces;
using NUnit.Framework;
using Moq;
using Newtonsoft.Json;
using Warewolf.UnitTestAttributes;

namespace Dev2.Tests.Runtime.Services
{
    [TestFixture]    
    public class GetDatabaseColumnsForTableTests
    {
        public static Depends _containerOps;

        [Test]
        [Author("Hagashen Naidu")]
        [Category("MSSql")]
        public void GetResourceID_ShouldReturnEmptyGuid()
        {
            //------------Setup for test--------------------------
            var getDatabaseColumnsForTable = new GetDatabaseColumnsForTable();

            //------------Execute Test---------------------------
            var resId = getDatabaseColumnsForTable.GetResourceID(new Dictionary<string, StringBuilder>());
            //------------Assert Results-------------------------
            Assert.AreEqual(Guid.Empty, resId);
        }

        [Test]
        [Author("Hagashen Naidu")]
        [Category("MSSql")]
        public void GetAuthorizationContextForService_ShouldReturnContext()
        {
            //------------Setup for test--------------------------
            var getDatabaseColumnsForTable = new GetDatabaseColumnsForTable();

            //------------Execute Test---------------------------
            var resId = getDatabaseColumnsForTable.GetAuthorizationContextForService();
            //------------Assert Results-------------------------
            Assert.AreEqual(AuthorizationContext.Any, resId);
        }

        #region Execute

        [Test]
        [Description("Service should never get null values")]
        [Author("Huggs")]
        [ExpectedException(typeof(InvalidDataContractException))]
        [Category("MSSql")]
        public void GetDatabaseColumnsForTable_UnitTest_ExecuteWithNullValues_ExpectedInvalidDataContractException()
        {
            var esb = new GetDatabaseColumnsForTable();
            var actual = esb.Execute(null, null);
            Assert.AreEqual(string.Empty, actual);
        }

        [Test]
        [Description("Service should never get null values")]
        [Author("Huggs")]
        [Category("MSSql")]
        public void GetDatabaseColumnsForTable_UnitTest_ExecuteWithNoDatabaseInValues_ExpectedHasErrors()
        {
            var esb = new GetDatabaseColumnsForTable();
            var actual = esb.Execute(new Dictionary<string, StringBuilder> { { "Database", null } }, null);
            Assert.IsNotNull(actual);
            var result = JsonConvert.DeserializeObject<DbColumnList>(actual.ToString());
            Assert.IsTrue(result.HasErrors);
            Assert.AreEqual("No database set.", result.Errors);
        }

        [Test]
        [Description("Service should never get null values")]
        [Author("Huggs")]
        [Category("MSSql")]
        public void GetDatabaseColumnsForTable_UnitTest_ExecuteWithNullDatabase_ExpectedHasErrors()
        {

            var esb = new GetDatabaseColumnsForTable();
            var actual = esb.Execute(new Dictionary<string, StringBuilder> { { "Database", null } }, null);
            Assert.IsNotNull(actual);
            var result = JsonConvert.DeserializeObject<DbColumnList>(actual.ToString());
            Assert.IsTrue(result.HasErrors);
            Assert.AreEqual("No database set.", result.Errors);
        }

        [Test]
        [Description("Service should never get null values")]
        [Author("Huggs")]
        [Category("MSSql")]
        public void GetDatabaseColumnsForTable_UnitTest_ExecuteWithBlankDatabase_ExpectedHasErrors()
        {
            var esb = new GetDatabaseColumnsForTable();
            var actual = esb.Execute(new Dictionary<string, StringBuilder> { { "Database", new StringBuilder() } }, null);
            Assert.IsNotNull(actual);
            var result = JsonConvert.DeserializeObject<DbColumnList>(actual.ToString());
            Assert.IsTrue(result.HasErrors);
            Assert.AreEqual("No database set.", result.Errors);
        }

        [Test]
        [Description("Service should never get null values")]
        [Author("Huggs")]
        [Category("MSSql")]
        public void GetDatabaseColumnsForTable_UnitTest_ExecuteWithNoTableNameInValues_ExpectedHasErrors()
        {

            var esb = new GetDatabaseColumnsForTable();
            var actual = esb.Execute(new Dictionary<string, StringBuilder> { { "Database", new StringBuilder("Test") }, { "Something", null } }, null);
            Assert.IsNotNull(actual);
            var result = JsonConvert.DeserializeObject<DbColumnList>(actual.ToString());
            Assert.IsTrue(result.HasErrors);
            Assert.AreEqual("No table name set.", result.Errors);
        }

        [Test]
        [Description("Service should never get null values")]
        [Author("Huggs")]
        [Category("MSSql")]
        public void GetDatabaseColumnsForTable_UnitTest_ExecuteWithNullTableNameExpectedHasErrors()
        {

            var esb = new GetDatabaseColumnsForTable();
            var actual = esb.Execute(new Dictionary<string, StringBuilder> { { "Database", new StringBuilder("Test") }, { "TableName", null } }, null);
            Assert.IsNotNull(actual);
            var result = JsonConvert.DeserializeObject<DbColumnList>(actual.ToString());
            Assert.IsTrue(result.HasErrors);
            Assert.AreEqual("No table name set.", result.Errors);
        }

        [Test]
        [Description("Service should never get null values")]
        [Author("Huggs")]
        [Category("MSSql")]
        public void GetDatabaseColumnsForTable_UnitTest_ExecuteWithBlankTableName_ExpectedHasErrors()
        {
            var esb = new GetDatabaseColumnsForTable();
            var actual = esb.Execute(new Dictionary<string, StringBuilder> { { "Database", new StringBuilder("Test") }, { "TableName", new StringBuilder() } }, null);
            Assert.IsNotNull(actual);
            var result = JsonConvert.DeserializeObject<DbColumnList>(actual.ToString());
            Assert.IsTrue(result.HasErrors);
            Assert.AreEqual("No table name set.", result.Errors);
        }


        [Test]
        [Author("Hagashen Naidu")]
        [Category("MSSql")]
        [Depends(Depends.ContainerType.MSSQL)]
        public void GetDatabaseColumnsForTable_Execute_ValidDatabaseSource_WithSchema_OnlyReturnsForThatSchema()
        {
            var parser = new Mock<IActivityParser>();
            parser.Setup(a => a.Parse(It.IsAny<DynamicActivity>())).Returns(new Mock<IDev2Activity>().Object);
            CustomContainer.Register(parser.Object);
            //------------Setup for test--------------------------
            var dbSource = CreateDev2TestingDbSource();
            ResourceCatalog.Instance.ResourceSaved = resource => { };
            ResourceCatalog.Instance.SaveResource(Guid.Empty, dbSource, "");
            var someJsonData = JsonConvert.SerializeObject(dbSource, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });
            var esb = new GetDatabaseColumnsForTable();
            var mockWorkspace = new Mock<IWorkspace>();
            mockWorkspace.Setup(workspace => workspace.ID).Returns(Guid.Empty);
            //------------Execute Test---------------------------
            var actual = esb.Execute(new Dictionary<string, StringBuilder> { { "Database", new StringBuilder(someJsonData) }, { "TableName", new StringBuilder("City") }, { "Schema", new StringBuilder("Warewolf") } }, mockWorkspace.Object);
            //------------Assert Results-------------------------
            var value = actual.ToString();
            Assert.IsFalse(string.IsNullOrEmpty(value));
            var result = JsonConvert.DeserializeObject<DbColumnList>(actual.ToString(), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });
            Assert.AreEqual(4, result.Items.Count);

            // Check Columns Returned ;)
            Assert.IsFalse(result.Items[0].IsNullable);
            Assert.IsTrue(result.Items[0].IsAutoIncrement);
            StringAssert.Contains(result.Items[0].ColumnName, "CityID");
            StringAssert.Contains(result.Items[0].SqlDataType.ToString(), "Int");

            Assert.IsFalse(result.Items[1].IsNullable);
            Assert.IsFalse(result.Items[1].IsAutoIncrement);
            StringAssert.Contains(result.Items[1].ColumnName, "Description");
            StringAssert.Contains(result.Items[1].SqlDataType.ToString(), "VarChar");

            Assert.IsFalse(result.Items[2].IsNullable);
            Assert.IsFalse(result.Items[2].IsAutoIncrement);
            StringAssert.Contains(result.Items[2].ColumnName, "CountryID");
            StringAssert.Contains(result.Items[2].SqlDataType.ToString(), "Int");

            Assert.IsTrue(result.Items[3].IsNullable);
            Assert.IsFalse(result.Items[3].IsAutoIncrement);
            StringAssert.Contains(result.Items[3].ColumnName, "TestCol");
            StringAssert.Contains(result.Items[3].SqlDataType.ToString(), "NChar");
        }

        [Test]
        [Author("Hagashen Naidu")]
        [Category("MSSql with Invalid Schema")]
        [Depends(Depends.ContainerType.MSSQL)]
        public void GetDatabaseColumnsForTable_Execute_NullSchema_ValidDatabaseSource_ReturnsFromAllSchemas()
        {
            var parser = new Mock<IActivityParser>();
            parser.Setup(a => a.Parse(It.IsAny<DynamicActivity>())).Returns(new Mock<IDev2Activity>().Object);
            CustomContainer.Register(parser.Object);
            //------------Setup for test--------------------------
            var dbSource = CreateDev2TestingDbSource();
            ResourceCatalog.Instance.ResourceSaved = resource => { };
            ResourceCatalog.Instance.SaveResource(Guid.Empty, dbSource, "");
            var someJsonData = JsonConvert.SerializeObject(dbSource,new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });
            var esb = new GetDatabaseColumnsForTable();
            var mockWorkspace = new Mock<IWorkspace>();
            mockWorkspace.Setup(workspace => workspace.ID).Returns(Guid.Empty);
            //------------Execute Test---------------------------
            var actual = esb.Execute(new Dictionary<string, StringBuilder> { { "Database", new StringBuilder(someJsonData) }, { "TableName", new StringBuilder("City") }, { "Schema", null } }, mockWorkspace.Object);
            //------------Assert Results-------------------------
            var value = actual.ToString();
            Assert.IsFalse(string.IsNullOrEmpty(value));
            var result = JsonConvert.DeserializeObject<DbColumnList>(actual.ToString(), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });
            Assert.AreEqual(3, result.Items.Count);

            // Check Columns Returned ;)
            Assert.IsFalse(result.Items[0].IsNullable);
            Assert.IsFalse(result.Items[0].IsAutoIncrement);
            StringAssert.Contains(result.Items[0].ColumnName, "CityID");
            StringAssert.Contains(result.Items[0].SqlDataType.ToString(), "Int");

            Assert.IsFalse(result.Items[1].IsNullable);
            Assert.IsFalse(result.Items[1].IsAutoIncrement);
            StringAssert.Contains(result.Items[1].ColumnName, "Description");
            StringAssert.Contains(result.Items[1].SqlDataType.ToString(), "VarChar");

            Assert.IsFalse(result.Items[2].IsNullable);
            Assert.IsFalse(result.Items[2].IsAutoIncrement);
            StringAssert.Contains(result.Items[2].ColumnName, "CountryID");
            StringAssert.Contains(result.Items[2].SqlDataType.ToString(), "Int");
        }

        [Test]
        [Author("Hagashen Naidu")]
        [Category("MSSql with Invalid Schema")]
        [Depends(Depends.ContainerType.MSSQL)]
        public void GetDatabaseColumnsForTable_Execute_EmptySchema_ValidDatabaseSource_ReturnsFromAllSchemas()
        {
            var parser = new Mock<IActivityParser>();
            parser.Setup(a => a.Parse(It.IsAny<DynamicActivity>())).Returns(new Mock<IDev2Activity>().Object);
            CustomContainer.Register(parser.Object);
            //------------Setup for test--------------------------
            var dbSource = CreateDev2TestingDbSource();
            ResourceCatalog.Instance.SaveResource(Guid.Empty, dbSource, "");
            var someJsonData = JsonConvert.SerializeObject(dbSource, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });
            var esb = new GetDatabaseColumnsForTable();
            var mockWorkspace = new Mock<IWorkspace>();
            mockWorkspace.Setup(workspace => workspace.ID).Returns(Guid.Empty);
            //------------Execute Test---------------------------
            var actual = esb.Execute(new Dictionary<string, StringBuilder> { { "Database", new StringBuilder(someJsonData) }, { "TableName", new StringBuilder("City") }, { "Schema", new StringBuilder("") } }, mockWorkspace.Object);
            //------------Assert Results-------------------------
            var value = actual.ToString();
            Assert.IsFalse(string.IsNullOrEmpty(value));
            var result = JsonConvert.DeserializeObject<DbColumnList>(actual.ToString(), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });
            Assert.AreEqual(3, result.Items.Count);

            // Check Columns Returned ;)
            Assert.IsFalse(result.Items[0].IsNullable);
            Assert.IsFalse(result.Items[0].IsAutoIncrement);
            StringAssert.Contains(result.Items[0].ColumnName, "CityID");
            StringAssert.Contains(result.Items[0].SqlDataType.ToString(), "Int");

            Assert.IsFalse(result.Items[1].IsNullable);
            Assert.IsFalse(result.Items[1].IsAutoIncrement);
            StringAssert.Contains(result.Items[1].ColumnName, "Description");
            StringAssert.Contains(result.Items[1].SqlDataType.ToString(), "VarChar");

            Assert.IsFalse(result.Items[2].IsNullable);
            Assert.IsFalse(result.Items[2].IsAutoIncrement);
            StringAssert.Contains(result.Items[2].ColumnName, "CountryID");
            StringAssert.Contains(result.Items[2].SqlDataType.ToString(), "Int");
        }

        static DbSource CreateDev2TestingDbSource()
        {
            _containerOps = new Depends(Depends.ContainerType.MSSQL);
            var dbSource = new DbSource
            {
                ResourceID = Guid.NewGuid(),
                ResourceName = "Dev2TestingDB",
                DatabaseName = "Dev2TestingDB",
                Server = Depends.EnableDocker?Depends.RigOpsIP:Depends.SVRDEVIP,
                AuthenticationType = AuthenticationType.User,
                ServerType = enSourceType.SqlDatabase,
                ReloadActions = true,
                UserID = "testUser",
                Password = "test123",
                ConnectionTimeout = 30
            };
            if (Depends.EnableDocker)
            {
                dbSource.Port = int.Parse(_containerOps.Container.Port);
            }
            return dbSource;
        }

        [TearDown]
        public void CleanupContainer() => _containerOps?.Dispose();

        #endregion

        #region HandlesType

        [Test]
        [Author("Huggs")]
        [Category("MSSql")]
        public void GetDatabaseColumnsForTable_UnitTest_HandlesType_ExpectedReturnsGetDatabaseColumnsForTableService()
        {
            var esb = new GetDatabaseColumnsForTable();
            var result = esb.HandlesType();
            Assert.AreEqual("GetDatabaseColumnsForTableService", result);
        }

        #endregion

        #region CreateServiceEntry

        [Test]
        [Description("Service should never get null values")]
        [Author("Huggs")]
        [Category("MSSql")]
        public void GetDatabaseColumnsForTable_UnitTest_CreateServiceEntry_ExpectedReturnsDynamicService()
        {
            var esb = new GetDatabaseColumnsForTable();
            var result = esb.CreateServiceEntry();
            Assert.AreEqual(esb.HandlesType(), result.Name);
            Assert.AreEqual("<DataList><Database ColumnIODirection=\"Input\"/><TableName ColumnIODirection=\"Input\"/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>", result.DataListSpecification.ToString());
            Assert.AreEqual(1, result.Actions.Count);

            var serviceAction = result.Actions[0];
            Assert.AreEqual(esb.HandlesType(), serviceAction.Name);
            Assert.AreEqual(enActionType.InvokeManagementDynamicService, serviceAction.ActionType);
            Assert.AreEqual(esb.HandlesType(), serviceAction.SourceMethod);
        }

        #endregion
    }
}
