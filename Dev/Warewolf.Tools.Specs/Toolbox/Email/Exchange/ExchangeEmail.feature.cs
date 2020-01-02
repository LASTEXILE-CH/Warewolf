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
namespace Warewolf.Tools.Specs.Toolbox.Email.Exchange
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ExchangeEmail")]
    [NUnit.Framework.CategoryAttribute("Email")]
    public partial class ExchangeEmailFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ExchangeEmail.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ExchangeEmail", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, new string[] {
                        "Email"});
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
        [NUnit.Framework.DescriptionAttribute("Send Exchange Email to multiple receipients")]
        public virtual void SendExchangeEmailToMultipleReceipients()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send Exchange Email to multiple receipients", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I have an exchange email variable \"[[firstMail]]\" equal to \"testmail@freemail.com" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I have an exchange email variable \"[[secondMail]]\" equal to \"test2@freemail.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("to exchange address is \"[[firstMail]];[[secondMail]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("the exchange subject is \"Just testing\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("exchange body is \"testing email from the cool specflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("the exchange email tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("the exchange email result will be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And("the exchange execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1484 = new TechTalk.SpecFlow.Table(new string[] {
                        "To",
                        "Subject",
                        "Body"});
            table1484.AddRow(new string[] {
                        "[[firstMail]];[[secondMail]] = testmail@freemail.com;test2@freemail.com",
                        "Just testing",
                        "testing email from the cool specflow"});
#line 16
 testRunner.And("the debug inputs as", ((string)(null)), table1484, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1485 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1485.AddRow(new string[] {
                        "[[result]] = Success"});
#line 19
 testRunner.And("the debug output as", ((string)(null)), table1485, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send Exchange email with no To Accounts")]
        public virtual void SendExchangeEmailWithNoToAccounts()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send Exchange email with no To Accounts", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
 testRunner.Given("exchange to address is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
 testRunner.And("the exchange subject is \"Just testing\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("exchange body is \"testing email from the cool specflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.When("the exchange email tool is executed \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("the exchange email result will be \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1486 = new TechTalk.SpecFlow.Table(new string[] {
                        "To",
                        "Subject",
                        "Body"});
            table1486.AddRow(new string[] {
                        "\"\"",
                        "Just testing",
                        "testing email from the cool specflow"});
#line 29
 testRunner.And("the debug inputs as", ((string)(null)), table1486, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1487 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1487.AddRow(new string[] {
                        "[[result]] ="});
#line 32
 testRunner.And("the debug output as", ((string)(null)), table1487, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send Exchange email with Subject as both text and variable as xml")]
        public virtual void SendExchangeEmailWithSubjectAsBothTextAndVariableAsXml()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send Exchange email with Subject as both text and variable as xml", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
 testRunner.Given("exchange to address is \"test1@freemail.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
 testRunner.And("I have an exchange email variable \"[[subject]]\" equal to \"<Wow>400%</Wow>\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("the exchange subject is \"News: [[subject]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("exchange body is \"testing email from the cool specflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.When("the exchange email tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("the exchange email result will be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.And("the exchange execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1488 = new TechTalk.SpecFlow.Table(new string[] {
                        "To",
                        "Subject",
                        "Body"});
            table1488.AddRow(new string[] {
                        "test1@freemail.com",
                        "News: [[subject]] = News: <Wow>400%</Wow>",
                        "testing email from the cool specflow"});
#line 44
 testRunner.And("the debug inputs as", ((string)(null)), table1488, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1489 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1489.AddRow(new string[] {
                        "[[result]] = Success"});
#line 47
 testRunner.And("the debug output as", ((string)(null)), table1489, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send exchange email with no body")]
        public virtual void SendExchangeEmailWithNoBody()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send exchange email with no body", ((string[])(null)));
#line 51
this.ScenarioSetup(scenarioInfo);
#line 52
 testRunner.Given("exchange to address is \"test1@freemail.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 53
 testRunner.And("the exchange subject is \"Testing this cool framework\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.When("the exchange email tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.Then("the exchange email result will be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.And("the exchange execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1490 = new TechTalk.SpecFlow.Table(new string[] {
                        "To",
                        "Subject",
                        "Body"});
            table1490.AddRow(new string[] {
                        "test1@freemail.com",
                        "Testing this cool framework",
                        "\"\""});
#line 57
 testRunner.And("the debug inputs as", ((string)(null)), table1490, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1491 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1491.AddRow(new string[] {
                        "[[result]] = Success"});
#line 60
 testRunner.And("the debug output as", ((string)(null)), table1491, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send exchange email with Body as both text and variable")]
        public virtual void SendExchangeEmailWithBodyAsBothTextAndVariable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send exchange email with Body as both text and variable", ((string[])(null)));
#line 64
this.ScenarioSetup(scenarioInfo);
#line 65
 testRunner.Given("exchange to address is \"test1@freemail.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 66
 testRunner.And("I have an exchange email variable \"[[body]]\" equal to \"<body><inner>inside</inner" +
                    "></body>\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("the exchange subject is \"News\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("exchange body is \"testing email from [[body]] the cool specflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.When("the exchange email tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
 testRunner.Then("the exchange email result will be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
 testRunner.And("the exchange execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1492 = new TechTalk.SpecFlow.Table(new string[] {
                        "To",
                        "Subject",
                        "Body"});
            table1492.AddRow(new string[] {
                        "test1@freemail.com",
                        "News",
                        "testing email from [[body]] the cool specflow = testing email from <body><inner>i" +
                            "nside</inner></body> the cool specflow"});
#line 72
 testRunner.And("the debug inputs as", ((string)(null)), table1492, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1493 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1493.AddRow(new string[] {
                        "[[result]] = Success"});
#line 75
 testRunner.And("the debug output as", ((string)(null)), table1493, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send exchange email with variable as Body that is xml")]
        public virtual void SendExchangeEmailWithVariableAsBodyThatIsXml()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send exchange email with variable as Body that is xml", ((string[])(null)));
#line 79
this.ScenarioSetup(scenarioInfo);
#line 80
 testRunner.Given("exchange to address is \"test1@freemail.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
 testRunner.And("I have an exchange email variable \"[[body]]\" equal to \"<body><inner>inside</inner" +
                    "></body>\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("the exchange subject is \"News\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And("exchange body is \"[[body]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.When("the exchange email tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
 testRunner.Then("the exchange email result will be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
 testRunner.And("the exchange execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1494 = new TechTalk.SpecFlow.Table(new string[] {
                        "To",
                        "Subject",
                        "Body"});
            table1494.AddRow(new string[] {
                        "test1@freemail.com",
                        "News",
                        "[[body]] =  <body><inner>inside</inner></body>"});
#line 87
 testRunner.And("the debug inputs as", ((string)(null)), table1494, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1495 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1495.AddRow(new string[] {
                        "[[result]] = Success"});
#line 90
 testRunner.And("the debug output as", ((string)(null)), table1495, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send exchange email with everything blank")]
        public virtual void SendExchangeEmailWithEverythingBlank()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send exchange email with everything blank", ((string[])(null)));
#line 94
this.ScenarioSetup(scenarioInfo);
#line 95
 testRunner.When("the exchange email tool is executed \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
 testRunner.Then("the exchange email result will be \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1496 = new TechTalk.SpecFlow.Table(new string[] {
                        "To",
                        "Subject",
                        "Body"});
            table1496.AddRow(new string[] {
                        "\"\"",
                        "\"\"",
                        "\"\""});
#line 97
 testRunner.And("the debug inputs as", ((string)(null)), table1496, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1497 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1497.AddRow(new string[] {
                        "[[result]] ="});
#line 100
 testRunner.And("the debug output as", ((string)(null)), table1497, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send exchange email with a negative index recordset for Recipients")]
        public virtual void SendExchangeEmailWithANegativeIndexRecordsetForRecipients()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send exchange email with a negative index recordset for Recipients", ((string[])(null)));
#line 104
this.ScenarioSetup(scenarioInfo);
#line 105
 testRunner.And("exchange to address is \"[[me(-1).to]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.And("the exchange subject is \"Just testing\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.And("exchange body is \"testing email from the cool specflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.When("the exchange email tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
 testRunner.Then("the exchange email result will be \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
 testRunner.And("the exchange execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1498 = new TechTalk.SpecFlow.Table(new string[] {
                        "To",
                        "Subject",
                        "Body"});
            table1498.AddRow(new string[] {
                        "[[me(-1).to]] =",
                        "Just testing",
                        "testing email from the cool specflow"});
#line 111
 testRunner.And("the debug inputs as", ((string)(null)), table1498, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1499 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1499.AddRow(new string[] {
                        "[[result]] ="});
#line 114
 testRunner.And("the debug output as", ((string)(null)), table1499, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send exchange email with a negative index recordset for Subject")]
        public virtual void SendExchangeEmailWithANegativeIndexRecordsetForSubject()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send exchange email with a negative index recordset for Subject", ((string[])(null)));
#line 118
this.ScenarioSetup(scenarioInfo);
#line 119
 testRunner.And("exchange to address is \"test1@freemail.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.And("the exchange subject is \"[[my(-1).subject]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.And("exchange body is \"testing email from the cool specflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.When("the exchange email tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 123
 testRunner.Then("the exchange email result will be \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 124
 testRunner.And("the exchange execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1500 = new TechTalk.SpecFlow.Table(new string[] {
                        "To",
                        "Subject",
                        "Body"});
            table1500.AddRow(new string[] {
                        "test1@freemail.com",
                        "[[my(-1).subject]] =",
                        "testing email from the cool specflow"});
#line 125
 testRunner.And("the debug inputs as", ((string)(null)), table1500, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1501 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1501.AddRow(new string[] {
                        "[[result]] ="});
#line 128
 testRunner.And("the debug output as", ((string)(null)), table1501, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send exchange email with a negative index recordset for Body")]
        public virtual void SendExchangeEmailWithANegativeIndexRecordsetForBody()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send exchange email with a negative index recordset for Body", ((string[])(null)));
#line 132
this.ScenarioSetup(scenarioInfo);
#line 133
 testRunner.And("to address is \"test1@freemail.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
 testRunner.And("exchange body is \"[[my(-1).body]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
 testRunner.When("the exchange email tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 136
 testRunner.Then("the exchange email result will be \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
 testRunner.And("the exchange execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1502 = new TechTalk.SpecFlow.Table(new string[] {
                        "To",
                        "Subject",
                        "Body"});
            table1502.AddRow(new string[] {
                        "test1@freemail.com",
                        "\"\"",
                        "[[my(-1).body]] ="});
#line 138
 testRunner.And("the debug inputs as", ((string)(null)), table1502, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1503 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1503.AddRow(new string[] {
                        "[[result]] ="});
#line 141
 testRunner.And("the debug output as", ((string)(null)), table1503, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send exchange email with new line in body")]
        public virtual void SendExchangeEmailWithNewLineInBody()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send exchange email with new line in body", ((string[])(null)));
#line 145
this.ScenarioSetup(scenarioInfo);
#line 146
 testRunner.Given("exchange to address is \"test1@freemail.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 147
 testRunner.And("the exchange subject is \"Testing this cool framework\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 148
 testRunner.And("exchange body is \"testing email with \\r\\n new line\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
 testRunner.When("the exchange email tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
 testRunner.Then("the exchange email result will be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 151
 testRunner.And("the exchange execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1504 = new TechTalk.SpecFlow.Table(new string[] {
                        "To",
                        "Subject",
                        "Body"});
            table1504.AddRow(new string[] {
                        "test1@freemail.com",
                        "Testing this cool framework",
                        "testing email with \\r\n new line"});
#line 152
 testRunner.And("the debug inputs as", ((string)(null)), table1504, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1505 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1505.AddRow(new string[] {
                        "[[result]] = Success"});
#line 155
 testRunner.And("the debug output as", ((string)(null)), table1505, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
