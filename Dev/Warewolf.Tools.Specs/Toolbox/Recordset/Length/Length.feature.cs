﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.Tools.Specs.Toolbox.Recordset.Length
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class LengthFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Length.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Length", "\tIn order to get the length of a records\r\n\tAs a Warewolf user\r\n\tI want a tool tha" +
                    "t takes a record set gives me its length", ProgrammingLanguage.CSharp, new string[] {
                        "Recordset"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Length")))
            {
                global::Warewolf.Tools.Specs.Toolbox.Recordset.Length.LengthFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Length of a recordset with 3 rows")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void LengthOfARecordsetWith3Rows()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Length of a recordset with 3 rows", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1347 = new TechTalk.SpecFlow.Table(new string[] {
                        "[[rs]]",
                        ""});
            table1347.AddRow(new string[] {
                        "rs(1).row",
                        "1"});
            table1347.AddRow(new string[] {
                        "rs(3).row",
                        "2"});
            table1347.AddRow(new string[] {
                        "rs(5).row",
                        "3"});
#line 8
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table1347, "Given ");
#line 13
 testRunner.And("get length on record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.Then("the length result should be 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1348 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
            table1348.AddRow(new string[] {
                        "[[rs(1).row]] = 1"});
            table1348.AddRow(new string[] {
                        "[[rs(3).row]] = 2"});
            table1348.AddRow(new string[] {
                        "[[rs(5).row]] = 3"});
#line 17
 testRunner.And("the debug inputs as", ((string)(null)), table1348, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1349 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1349.AddRow(new string[] {
                        "[[result]] = 5"});
#line 22
 testRunner.And("the debug output as", ((string)(null)), table1349, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Length of a recordset with 8 rows")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void LengthOfARecordsetWith8Rows()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Length of a recordset with 8 rows", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1350 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table1350.AddRow(new string[] {
                        "rs(1).row",
                        "1"});
            table1350.AddRow(new string[] {
                        "rs(2).row",
                        "2"});
            table1350.AddRow(new string[] {
                        "rs(3).row",
                        "3"});
            table1350.AddRow(new string[] {
                        "rs(4).row",
                        "4"});
            table1350.AddRow(new string[] {
                        "rs(5).row",
                        "5"});
            table1350.AddRow(new string[] {
                        "rs(6).row",
                        "6"});
            table1350.AddRow(new string[] {
                        "rs(7).row",
                        "7"});
            table1350.AddRow(new string[] {
                        "rs(8).row",
                        "8"});
#line 27
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table1350, "Given ");
#line 37
 testRunner.And("get length on record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("the length result should be 8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1351 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
            table1351.AddRow(new string[] {
                        "[[rs(1).row]] =  1"});
            table1351.AddRow(new string[] {
                        "[[rs(2).row]] =  2"});
            table1351.AddRow(new string[] {
                        "[[rs(3).row]] =  3"});
            table1351.AddRow(new string[] {
                        "[[rs(4).row]] =  4"});
            table1351.AddRow(new string[] {
                        "[[rs(5).row]] =  5"});
            table1351.AddRow(new string[] {
                        "[[rs(6).row]] =  6"});
            table1351.AddRow(new string[] {
                        "[[rs(7).row]] =  7"});
            table1351.AddRow(new string[] {
                        "[[rs(8).row]] =  8"});
#line 41
 testRunner.And("the debug inputs as", ((string)(null)), table1351, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1352 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1352.AddRow(new string[] {
                        "[[result]] = 8"});
#line 51
 testRunner.And("the debug output as", ((string)(null)), table1352, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Recordset length for coloumn")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void RecordsetLengthForColoumn()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Recordset length for coloumn", ((string[])(null)));
#line 55
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1353 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table1353.AddRow(new string[] {
                        "rs(1).row",
                        "1"});
            table1353.AddRow(new string[] {
                        "rs(2).row",
                        "2"});
            table1353.AddRow(new string[] {
                        "rs(3).row",
                        "3"});
            table1353.AddRow(new string[] {
                        "rs(4).row",
                        "4"});
            table1353.AddRow(new string[] {
                        "rs(5).row",
                        "5"});
            table1353.AddRow(new string[] {
                        "rs(6).row",
                        "6"});
            table1353.AddRow(new string[] {
                        "rs(7).row",
                        "7"});
            table1353.AddRow(new string[] {
                        "rs(8).row",
                        "8"});
#line 56
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table1353, "Given ");
#line 66
 testRunner.And("get length on record \"[[rs().row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1354 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
#line 69
 testRunner.And("the debug inputs as", ((string)(null)), table1354, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1355 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 71
 testRunner.And("the debug output as", ((string)(null)), table1355, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Recordset length for coloumns invalid")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void RecordsetLengthForColoumnsInvalid()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Recordset length for coloumns invalid", ((string[])(null)));
#line 74
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1356 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table1356.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1356.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1356.AddRow(new string[] {
                        "rs().row",
                        "3"});
            table1356.AddRow(new string[] {
                        "rs().row",
                        "4"});
            table1356.AddRow(new string[] {
                        "rs().row2",
                        "5"});
            table1356.AddRow(new string[] {
                        "rs().row2",
                        "6"});
            table1356.AddRow(new string[] {
                        "rs().row2",
                        "7"});
#line 75
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table1356, "Given ");
#line 84
 testRunner.And("get length on record \"[[rs().row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 86
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1357 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
#line 87
 testRunner.And("the debug inputs as", ((string)(null)), table1357, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1358 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 89
 testRunner.And("the debug output as", ((string)(null)), table1358, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Recordset length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void RecordsetLength()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Recordset length", ((string[])(null)));
#line 92
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1359 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table1359.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1359.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1359.AddRow(new string[] {
                        "rs().row",
                        "3"});
            table1359.AddRow(new string[] {
                        "rs().row",
                        "4"});
            table1359.AddRow(new string[] {
                        "rs().row2",
                        "5"});
            table1359.AddRow(new string[] {
                        "rs().row2",
                        "6"});
            table1359.AddRow(new string[] {
                        "rs().row2",
                        "7"});
#line 93
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table1359, "Given ");
#line 102
 testRunner.And("get length on record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
 testRunner.Then("the length result should be 6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1360 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
            table1360.AddRow(new string[] {
                        "[[rs(1).row]] =  1"});
            table1360.AddRow(new string[] {
                        "[[rs(2).row]] =  2"});
            table1360.AddRow(new string[] {
                        "[[rs(3).row]] =  3"});
            table1360.AddRow(new string[] {
                        "[[rs(4).row]] =  4"});
            table1360.AddRow(new string[] {
                        "[[rs(4).row2]] =  5"});
            table1360.AddRow(new string[] {
                        "[[rs(5).row2]] =  6"});
            table1360.AddRow(new string[] {
                        "[[rs(6).row2]] =  7"});
#line 106
 testRunner.And("the debug inputs as", ((string)(null)), table1360, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1361 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1361.AddRow(new string[] {
                        "[[result]] = 6"});
#line 115
 testRunner.And("the debug output as", ((string)(null)), table1361, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Recordset length for invalid recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void RecordsetLengthForInvalidRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Recordset length for invalid recordset", ((string[])(null)));
#line 119
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1362 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table1362.AddRow(new string[] {
                        "rs(1).row",
                        "1"});
            table1362.AddRow(new string[] {
                        "rs(2).row",
                        "2"});
            table1362.AddRow(new string[] {
                        "rs(3).row",
                        "3"});
            table1362.AddRow(new string[] {
                        "rs(4).row",
                        "4"});
            table1362.AddRow(new string[] {
                        "rs(5).row",
                        "5"});
            table1362.AddRow(new string[] {
                        "rs(6).row",
                        "6"});
            table1362.AddRow(new string[] {
                        "rs(7).row",
                        "7"});
            table1362.AddRow(new string[] {
                        "rs(8).row",
                        "8"});
#line 120
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table1362, "Given ");
#line 130
 testRunner.And("get length on record \"[[rs().&^]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1363 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
#line 133
 testRunner.And("the debug inputs as", ((string)(null)), table1363, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1364 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 135
 testRunner.And("the debug output as", ((string)(null)), table1364, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected(string variable, string val, string error, string message, string result, string value, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure Recordset length inputs work as expected", exampleTags);
#line 138
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1365 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table1365.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1365.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1365.AddRow(new string[] {
                        "rs().row",
                        "3"});
            table1365.AddRow(new string[] {
                        "rs().row",
                        "4"});
            table1365.AddRow(new string[] {
                        "rs().row2",
                        "5"});
            table1365.AddRow(new string[] {
                        "rs().row2",
                        "6"});
            table1365.AddRow(new string[] {
                        "rs().row2",
                        "7"});
#line 139
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table1365, "Given ");
#line 148
 testRunner.And(string.Format("get length on record \"{0}\"", variable), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
 testRunner.Then(string.Format("the execution has \"{0}\" error", error), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: [[a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "[[a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "[[a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "The")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "Scalar not allowed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[b]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "[[b]] = failure")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_A()
        {
#line 138
this.EnsureRecordsetLengthInputsWorkAsExpected("[[a]]", "The", "AN", "Scalar not allowed", "[[b]]", "[[b]] = failure", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: \"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[rec(1).a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "0")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_()
        {
#line 138
this.EnsureRecordsetLengthInputsWorkAsExpected("\"\"", "\"\"", "AN", "", "[[rec(1).a]]", "0", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: dfsd")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "dfsd")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "dfsd")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "dfsd")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "Invalid characters have been entered as Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[rec(*).a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "Failure")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_Dfsd()
        {
#line 138
this.EnsureRecordsetLengthInputsWorkAsExpected("dfsd", "dfsd", "AN", "Invalid characters have been entered as Recordset", "[[rec(*).a]]", "Failure", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: 12")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "12")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "12")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "12")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "Invalid characters have been entered as Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[rec([[int]]).a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "Failure")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_12()
        {
#line 138
this.EnsureRecordsetLengthInputsWorkAsExpected("12", "12", "AN", "Invalid characters have been entered as Recordset", "[[rec([[int]]).a]]", "Failure", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: [[rec(1)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "[[rec(1)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "[[rec(1)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[rs().a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "[[rs(1).a]] = 3")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_Rec1()
        {
#line 138
this.EnsureRecordsetLengthInputsWorkAsExpected("[[rec(1)]]", "\"\"", "AN", "", "[[rs().a]]", "[[rs(1).a]] = 3", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: [[rec(*)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "[[rec(*)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "[[rec(*)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "Blank result variable")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "\"\"")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_Rec()
        {
#line 138
this.EnsureRecordsetLengthInputsWorkAsExpected("[[rec(*)]]", "\"\"", "AN", "Blank result variable", "\"\"", "\"\"", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: [[rec([[int]])]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "[[rec([[int]])]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "[[rec([[int]])]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[sdasd]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "3")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_RecInt()
        {
#line 138
this.EnsureRecordsetLengthInputsWorkAsExpected("[[rec([[int]])]]", "\"\"", "AN", "", "[[sdasd]]", "3", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: [[c]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "[[c]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "[[c]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "Scalar not allowed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[d]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "Failure")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_C()
        {
#line 138
this.EnsureRecordsetLengthInputsWorkAsExpected("[[c]]", "\"\"", "AN", "Scalar not allowed", "[[d]]", "Failure", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Length of an null recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void LengthOfAnNullRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Length of an null recordset", ((string[])(null)));
#line 162
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1366 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table1366.AddRow(new string[] {
                        "[[rs().row]]",
                        "NULL"});
#line 163
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table1366, "Given ");
#line 166
 testRunner.And("get length on record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 167
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 168
 testRunner.Then("the length result should be 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 169
 testRunner.And("the execution has \"No\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Length of an unassigned recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void LengthOfAnUnassignedRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Length of an unassigned recordset", ((string[])(null)));
#line 171
this.ScenarioSetup(scenarioInfo);
#line 172
 testRunner.Given("get length on record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 173
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 174
 testRunner.Then("the execution has \"An\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
