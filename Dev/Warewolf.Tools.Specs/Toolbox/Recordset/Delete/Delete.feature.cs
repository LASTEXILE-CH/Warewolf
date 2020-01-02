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
namespace Warewolf.Tools.Specs.Toolbox.Recordset.Delete
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Delete")]
    [NUnit.Framework.CategoryAttribute("Recordset")]
    public partial class DeleteFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Delete.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Delete", "\tIn order to delete records\r\n\tAs a Warewolf user\r\n\tI want a tool that takes a rec" +
                    "ord set and deletes it", ProgrammingLanguage.CSharp, new string[] {
                        "Recordset"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete last record in a recordset")]
        public virtual void DeleteLastRecordInARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete last record in a recordset", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1823 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1823.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1823.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1823.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 9
 testRunner.Given("I have the following recordset", ((string)(null)), table1823, "Given ");
#line 14
 testRunner.And("I delete a record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.Then("the delete result should be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1824 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1824.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1824.AddRow(new string[] {
                        "rs().row",
                        "2"});
#line 17
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table1824, "And ");
#line 21
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1825 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table1825.AddRow(new string[] {
                        "[[rs(3).row]] = 3"});
#line 22
 testRunner.And("the debug inputs as", ((string)(null)), table1825, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1826 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1826.AddRow(new string[] {
                        "[[result]] = Success"});
#line 25
 testRunner.And("the debug output as", ((string)(null)), table1826, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1827 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1827.AddRow(new string[] {
                        "[[result]] = Success"});
#line 28
 testRunner.And("the debug output as", ((string)(null)), table1827, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete an invalid recordset (recordset with no fields declared)")]
        public virtual void DeleteAnInvalidRecordsetRecordsetWithNoFieldsDeclared()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete an invalid recordset (recordset with no fields declared)", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1828 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1828.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1828.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1828.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 33
 testRunner.Given("I have the following recordset", ((string)(null)), table1828, "Given ");
#line 38
 testRunner.And("I delete a record \"[[GG()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1829 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table1829.AddRow(new string[] {
                        "[[GG()]] ="});
#line 42
 testRunner.And("the debug inputs as", ((string)(null)), table1829, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1830 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1830.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 45
 testRunner.And("the debug output as", ((string)(null)), table1830, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete the first record in a recordset")]
        public virtual void DeleteTheFirstRecordInARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete the first record in a recordset", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1831 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1831.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1831.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1831.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 50
 testRunner.Given("I have the following recordset", ((string)(null)), table1831, "Given ");
#line 55
 testRunner.And("I delete a record \"[[rs(1)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
 testRunner.Then("the delete result should be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1832 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1832.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1832.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 58
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table1832, "And ");
#line 62
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1833 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table1833.AddRow(new string[] {
                        "[[rs(1).row]] = 1"});
#line 63
 testRunner.And("the debug inputs as", ((string)(null)), table1833, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1834 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1834.AddRow(new string[] {
                        "[[result]] = Success"});
#line 66
 testRunner.And("the debug output as", ((string)(null)), table1834, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete a record using an index from a variable")]
        public virtual void DeleteARecordUsingAnIndexFromAVariable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record using an index from a variable", ((string[])(null)));
#line 70
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1835 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1835.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1835.AddRow(new string[] {
                        "rs().row",
                        "6"});
            table1835.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 71
 testRunner.Given("I have the following recordset", ((string)(null)), table1835, "Given ");
#line 76
 testRunner.And("an index \"[[index]]\" exists with a value \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("I delete a record \"[[rs([[index]])]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
 testRunner.Then("the delete result should be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1836 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1836.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1836.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 80
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table1836, "And ");
#line 84
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1837 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table1837.AddRow(new string[] {
                        "[[rs(2).row]] = 6"});
#line 85
 testRunner.And("the debug inputs as", ((string)(null)), table1837, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1838 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1838.AddRow(new string[] {
                        "[[result]] = Success"});
#line 88
 testRunner.And("the debug output as", ((string)(null)), table1838, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete a record using a star notation")]
        public virtual void DeleteARecordUsingAStarNotation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record using a star notation", ((string[])(null)));
#line 92
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1839 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1839.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1839.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1839.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 93
 testRunner.Given("I have the following recordset", ((string)(null)), table1839, "Given ");
#line 98
 testRunner.And("I delete a record \"[[rs(*)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.Then("the delete result should be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1840 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
#line 101
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table1840, "And ");
#line 103
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1841 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table1841.AddRow(new string[] {
                        "[[rs(1).row]] = 1"});
            table1841.AddRow(new string[] {
                        "[[rs(2).row]] = 2"});
            table1841.AddRow(new string[] {
                        "[[rs(3).row]] = 3"});
#line 104
 testRunner.And("the debug inputs as", ((string)(null)), table1841, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1842 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1842.AddRow(new string[] {
                        "[[result]] = Success"});
#line 109
 testRunner.And("the debug output as", ((string)(null)), table1842, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete a record using a negative integer -1")]
        public virtual void DeleteARecordUsingANegativeInteger_1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record using a negative integer -1", ((string[])(null)));
#line 113
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1843 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1843.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1843.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1843.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 114
 testRunner.Given("I have the following recordset", ((string)(null)), table1843, "Given ");
#line 119
 testRunner.And("I delete a record \"[[rs(-1)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 121
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1844 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1844.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1844.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1844.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 122
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table1844, "And ");
#line 127
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1845 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table1845.AddRow(new string[] {
                        "[[rs(-1)]]  ="});
#line 128
 testRunner.And("the debug inputs as", ((string)(null)), table1845, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1846 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1846.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 131
 testRunner.And("the debug output as", ((string)(null)), table1846, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete a record that does not exist")]
        public virtual void DeleteARecordThatDoesNotExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record that does not exist", ((string[])(null)));
#line 135
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1847 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1847.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1847.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1847.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 136
 testRunner.Given("I have the following recordset", ((string)(null)), table1847, "Given ");
#line 141
 testRunner.And("I delete a record \"[[rs(5)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 143
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1848 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1848.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1848.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1848.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 144
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table1848, "And ");
#line 149
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1849 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table1849.AddRow(new string[] {
                        "[[rs(5)]]  ="});
#line 150
 testRunner.And("the debug inputs as", ((string)(null)), table1849, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1850 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1850.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 153
 testRunner.And("the debug output as", ((string)(null)), table1850, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete a record an empty recordset")]
        public virtual void DeleteARecordAnEmptyRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record an empty recordset", ((string[])(null)));
#line 157
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1851 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
#line 158
 testRunner.Given("I have the following recordset", ((string)(null)), table1851, "Given ");
#line 160
 testRunner.And("I delete a record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 162
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 163
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1852 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table1852.AddRow(new string[] {
                        "[[rs()]]  ="});
#line 164
 testRunner.And("the debug inputs as", ((string)(null)), table1852, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1853 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1853.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 167
 testRunner.And("the debug output as", ((string)(null)), table1853, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete a scalar insted of a recordset")]
        public virtual void DeleteAScalarInstedOfARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a scalar insted of a recordset", ((string[])(null)));
#line 171
this.ScenarioSetup(scenarioInfo);
#line 172
 testRunner.Given("I have a delete variable \"[[var]]\" equal to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 173
 testRunner.And("I delete a record \"[[var]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 174
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 175
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 176
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1854 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
#line 177
 testRunner.And("the debug inputs as", ((string)(null)), table1854, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1855 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1855.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 179
 testRunner.And("the debug output as", ((string)(null)), table1855, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete two recordset data.")]
        public virtual void DeleteTwoRecordsetData_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete two recordset data.", ((string[])(null)));
#line 183
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1856 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1856.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1856.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1856.AddRow(new string[] {
                        "ws().row",
                        "3"});
            table1856.AddRow(new string[] {
                        "ws().row",
                        "4"});
#line 184
 testRunner.Given("I have the following recordset", ((string)(null)), table1856, "Given ");
#line 190
 testRunner.And("I delete a record \"[[rs(*)]],[[ws(*)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 192
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1857 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
            table1857.AddRow(new string[] {
                        "[[rs(1).row]]",
                        "1"});
            table1857.AddRow(new string[] {
                        "[[rs(1).row]]",
                        "2"});
#line 193
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table1857, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1858 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
            table1858.AddRow(new string[] {
                        "[[ws(1).row]]",
                        "3"});
            table1858.AddRow(new string[] {
                        "[[ws(2).row]]",
                        "4"});
#line 197
 testRunner.And("the recordset \"[[ws(*).row]]\" will be as follows", ((string)(null)), table1858, "And ");
#line 201
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1859 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
#line 202
 testRunner.And("the debug inputs as", ((string)(null)), table1859, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1860 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1860.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 204
 testRunner.And("the debug output as", ((string)(null)), table1860, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete two specific recordset data.")]
        public virtual void DeleteTwoSpecificRecordsetData_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete two specific recordset data.", ((string[])(null)));
#line 208
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1861 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1861.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1861.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1861.AddRow(new string[] {
                        "rs().row",
                        "3"});
            table1861.AddRow(new string[] {
                        "rs().row",
                        "4"});
#line 209
 testRunner.Given("I have the following recordset", ((string)(null)), table1861, "Given ");
#line 215
 testRunner.And("I delete a record \"[[rs(1).a]],[[rs(4).a]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 216
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 217
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1862 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
            table1862.AddRow(new string[] {
                        "[[rs().row]]",
                        "1"});
            table1862.AddRow(new string[] {
                        "[[rs().row]]",
                        "2"});
            table1862.AddRow(new string[] {
                        "[[rs().row]]",
                        "3"});
            table1862.AddRow(new string[] {
                        "[[rs().row]]",
                        "4"});
#line 218
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table1862, "And ");
#line 224
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1863 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
#line 225
 testRunner.And("the debug inputs as", ((string)(null)), table1863, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1864 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1864.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 227
 testRunner.And("the debug output as", ((string)(null)), table1864, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ensure delete variables of different types produce desired results")]
        [NUnit.Framework.TestCaseAttribute("\"\"", "\"\"", "An", "Failure", null)]
        [NUnit.Framework.TestCaseAttribute("99", "99", "An", "Failure", null)]
        [NUnit.Framework.TestCaseAttribute("[[q]]", "", "An", "Failure", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "An", "Failure", null)]
        [NUnit.Framework.TestCaseAttribute("[[Rec([[var]]).set]]", "", "An", "Failure", null)]
        public virtual void EnsureDeleteVariablesOfDifferentTypesProduceDesiredResults(string variable, string value, string error, string message, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure delete variables of different types produce desired results", exampleTags);
#line 232
this.ScenarioSetup(scenarioInfo);
#line 233
 testRunner.Given(string.Format("I have a delete variable \"{0}\" equal to \"{1}\"", variable, value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 234
 testRunner.And(string.Format("I delete a record \"{0}\"", variable), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 235
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 236
 testRunner.Then(string.Format("the delete result should be \"{0}\"", message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1865 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
#line 237
 testRunner.And("the debug inputs as", ((string)(null)), table1865, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1866 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1866.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 239
 testRunner.And("the debug output as", ((string)(null)), table1866, "And ");
#line 242
 testRunner.And(string.Format("the execution has \"{0}\" error", error), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
