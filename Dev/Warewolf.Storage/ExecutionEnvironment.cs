﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dev2.Common.Common;
using Dev2.Common.Interfaces;
using Newtonsoft.Json.Linq;
using WarewolfParserInterop;

namespace Warewolf.Storage
{

    public interface IExecutionEnvironment
    {
        CommonFunctions.WarewolfEvalResult Eval(string exp,int update,bool throwsifnotexists=true);

        CommonFunctions.WarewolfEvalResult EvalStrict(string exp, int update);
        void Assign(string exp, string value, int update);


        void AssignWithFrame(IAssignValue values, int update);


        int GetLength(string recordSetName);

        int GetCount(string recordSetName);

        IList<int> EvalRecordSetIndexes(string recordsetName,int update);

        bool HasRecordSet(string recordsetName);

        IList<string> EvalAsListOfStrings(string expression, int update);

        void EvalAssignFromNestedStar(string exp, CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult recsetResult, int update);

        void EvalAssignFromNestedLast(string exp, CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult recsetResult,int update);

        void EvalAssignFromNestedNumeric(string rawValue, CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult recsetResult, int update);

        void EvalDelete(string exp, int update);

        void CommitAssign();

        void SortRecordSet(string sortField, bool descOrder, int update);

        string ToStar(string expression);

        IEnumerable<DataASTMutable.WarewolfAtom> EvalAsList(string searchCriteria, int update,bool throwsifnotexists = false);

        IEnumerable<int> EvalWhere(string expression, Func<DataASTMutable.WarewolfAtom, bool> clause, int update);

        void ApplyUpdate(string expression, Func<DataASTMutable.WarewolfAtom, DataASTMutable.WarewolfAtom> clause, int update);

        HashSet<string> Errors { get; }
        HashSet<string> AllErrors { get; } 
        void AddError(string error);

      

        void AssignDataShape(string p);

        string FetchErrors();

        bool HasErrors();


        string EvalToExpression(string exp, int update);

        IEnumerable<CommonFunctions.WarewolfEvalResult> EvalForDataMerge(string exp, int update);

        void AssignUnique(IEnumerable<string> distinctList, IEnumerable<string> valueList, IEnumerable<string> resList,int update);

        CommonFunctions.WarewolfEvalResult EvalForJson(string exp);

        void AddToJsonObjects(string bob, JContainer jContainer);
    }
    public class ExecutionEnvironment : IExecutionEnvironment
    {
        DataASTMutable.WarewolfEnvironment _env;

        public  ExecutionEnvironment()
        {
            _env = PublicFunctions.CreateEnv("");
            Errors = new HashSet<string>();
            AllErrors = new HashSet<string>(); 
        }

        public CommonFunctions.WarewolfEvalResult Eval(string exp, int update,bool throwsifnotexists = false)
        {
      
            try
            {
                return PublicFunctions.EvalEnvExpression(exp,update, _env);
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            catch (Exception e)
            {
                if (throwsifnotexists||e is IndexOutOfRangeException || e.Message.Contains("index was not an int")) throw;
                return CommonFunctions.WarewolfEvalResult.NewWarewolfAtomResult(DataASTMutable.WarewolfAtom.Nothing);
            }

        }


          public CommonFunctions.WarewolfEvalResult EvalForJson(string exp)
        {
            if (string.IsNullOrEmpty(exp))
            {
                return CommonFunctions.WarewolfEvalResult.NewWarewolfAtomResult(DataASTMutable.WarewolfAtom.Nothing);
            }
            try
            {
                return PublicFunctions.EvalEnvExpression(exp, 0,_env);
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            catch (Exception e)
            {
                if (e is IndexOutOfRangeException) throw;
                if(IsRecordsetIdentifier(exp))
                {
                   var res =  new WarewolfAtomList<DataASTMutable.WarewolfAtom>(DataASTMutable.WarewolfAtom.Nothing);
                    res.AddNothing();
                    return CommonFunctions.WarewolfEvalResult.NewWarewolfAtomListresult(res);    
                }
                    return CommonFunctions.WarewolfEvalResult.NewWarewolfAtomResult(DataASTMutable.WarewolfAtom.Nothing);
            }

        }

        public void AddToJsonObjects(string bob, JContainer jContainer)
        {
            JObject j = JObject.FromObject(new Person()
            {
                Name = "n",
                Children = new List<Person>
                {
                    new Person()
                    {
                        Name = "p", Children = new List<Person>{       new Person()
                    {
                        Name = "r", Children = new List<Person>()
                    },        new Person()
                    {
                        Name = "s", Children = new List<Person>()
                    } }

                    }, 
                    new Person()
                    {
                        Name = "q", Children = new List<Person>(){       new Person()
                    {
                        Name = "r", Children = new List<Person>()
                    },        new Person()
                    {
                        Name = "s", Children = new List<Person>()
                    } }
                    }
                },
                Spouse = new Person()
                {
                    Name = "o",
                    Children = new List<Person>()
                }
            });
            _env = AssignEvaluation.addToJsonObjects(_env, "bob", j);
        }

        public IEnumerable< CommonFunctions.WarewolfEvalResult> EvalForDataMerge(string exp, int update)
        {
            return DataMergeFunctions.evalForDataMerge( _env, update,exp);
        }

        public void AssignUnique(IEnumerable<string> distinctList, IEnumerable<string> valueList, IEnumerable<string> resList, int update)
        {
           var output =  Distinct.evalDistinct(_env, distinctList, valueList,update,resList);
           _env = output;
        }

        public CommonFunctions.WarewolfEvalResult EvalStrict(string exp,int update)
        {
            var res =  Eval(exp, update);
            if(IsNothing( res))
                throw new NullValueInVariableException("The expression"+exp+"has no value assigned",exp);
            return res;
        }

        public void Assign(string exp, string value, int update)
        {
            if (string.IsNullOrEmpty(exp))
            {
                return ;
            }

            
            var envTemp =  PublicFunctions.EvalAssignWithFrame( new AssignValue( exp,value),update, _env);
            
            _env = envTemp;
            CommitAssign();
           
        }

        public void AssignWithFrame(IAssignValue values, int update)
        {
            try
            {
            if (string.IsNullOrEmpty(values.Name))
            {
                return ;
            }

            var envTemp = PublicFunctions.EvalAssignWithFrame(values, update,_env);
            _env = envTemp;
            }
            catch (Exception err)
            {

                Errors.Add(err.Message);
                throw;
            }
        }

        public int GetLength(string recordSetName)
        {
            return _env.RecordSets[recordSetName.Trim()].LastIndex;
        }

        public int GetCount(string recordSetName)
        {
            return _env.RecordSets[recordSetName.Trim()].Count;
        }



        public IList<int> EvalRecordSetIndexes(string recordsetName, int update)
        {
           
            return PublicFunctions.GetIndexes(recordsetName, update, _env).ToList();
        }

        public bool HasRecordSet(string recordsetName)
        {
            var x = WarewolfDataEvaluationCommon.parseLanguageExpression(recordsetName,0);
            if(x.IsRecordSetNameExpression)
            {
                var recsetName = x as LanguageAST.LanguageExpression.RecordSetNameExpression;
                // ReSharper disable PossibleNullReferenceException
                return _env.RecordSets.ContainsKey(recsetName.Item.Name);
                // ReSharper restore PossibleNullReferenceException
            }
            return false;
            
        }

        public IList<string> EvalAsListOfStrings(string expression,int update)
        {
            var result = Eval(expression, update);
            if (result.IsWarewolfAtomResult)
            {
                // ReSharper disable PossibleNullReferenceException
                var x = (result as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult).Item;
                // ReSharper restore PossibleNullReferenceException
                return new List<string> { WarewolfAtomToString(x) };
            }
                // ReSharper disable PossibleNullReferenceException
                // ReSharper disable PossibleNullReferenceException
                var warewolfAtomListresult = result as CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult;
                if(warewolfAtomListresult != null)
                {
                    var x = warewolfAtomListresult.Item;
                    // ReSharper restore PossibleNullReferenceException
                    return x.Select(WarewolfAtomToString).ToList();
                }
                throw new Exception(string.Format("Could not retrieve list of strings from expression {0}", expression));
            }

        public static  string WarewolfAtomToString(DataASTMutable.WarewolfAtom a)
        {
            if (a == null)
            {
                return "";
            }
            return a.ToString();
        }

        public static string WarewolfAtomToStringNullAsNothing(DataASTMutable.WarewolfAtom a)
        {
            return a == null ? null : (a.IsNothing ? null : a.ToString());
        }

        public static string WarewolfAtomToStringErrorIfNull(DataASTMutable.WarewolfAtom a)
        {
            if (a == null)
            {
                return "";
            }
            if(a.IsNothing)
            {
                throw new NullValueInVariableException("Variable is null","");
            }
            return a.ToString();
        }

        public static bool IsRecordSetName(string a)
        {
            try
            {
                var x = WarewolfDataEvaluationCommon.parseLanguageExpression(a,0);
                return x.IsRecordSetNameExpression;
            }
            catch(Exception)
            {
                return false;
                
            }
        }

        public static bool IsValidVariableExpression(string expression, out string errorMessage,int update)
        {
            errorMessage = "";
            try
            {
                var x = WarewolfDataEvaluationCommon.parseLanguageExpression(expression,update);
                if (x.IsRecordSetExpression || x.IsScalarExpression)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }
            return false;
        }

        public static string WarewolfEvalResultToString(CommonFunctions.WarewolfEvalResult result)
        {
         
            if (result.IsWarewolfAtomResult)
            {
                // ReSharper disable PossibleNullReferenceException
                var warewolfAtomResult = result as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult;
                if(warewolfAtomResult != null)
                {
                    var x = warewolfAtomResult.Item;
                    if (x.IsNothing) return null;
                // ReSharper restore PossibleNullReferenceException
                return WarewolfAtomToStringErrorIfNull(x);
            }
                throw new Exception("null when f# said it should not be");
            }
                // ReSharper disable RedundantIfElseBlock
            else
                // ReSharper restore RedundantIfElseBlock
            {
                // ReSharper disable PossibleNullReferenceException
                var warewolfAtomListresult = result as CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult;
                if(warewolfAtomListresult != null)
                {
                    var x = warewolfAtomListresult.Item;
                StringBuilder res = new StringBuilder(); 
                for(int index  = 0; index < x.Count; index++)
                {
                    var warewolfAtom = x[index];
                    if(index==x.Count-1)
                    {
                        res.Append(warewolfAtom);
                    }
                    else
                    {
                        res.Append(warewolfAtom).Append(",");
                    }
                }
                return res.ToString();
            }
                throw new Exception("null when f# said it should not be");
            }
        }

        public void EvalAssignFromNestedStar(string exp, CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult recsetResult,int update)
        {
            AssignWithFrameAndList(exp, recsetResult.Item, false, update);
        }
        public void EvalAssignFromNestedLast(string exp, CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult recsetResult,int update)
        {
            bool exists = PublicFunctions.RecordsetExpressionExists(exp, _env);
            if (!exists)
                exp = ToStar(exp);
            AssignWithFrameAndList(exp, recsetResult.Item, exists, update);
        }

        // ReSharper disable once ParameterTypeCanBeEnumerable.Local
        void AssignWithFrameAndList(string assignValue, WarewolfAtomList<DataASTMutable.WarewolfAtom> item, bool shouldUseLast,int update)
        {
           _env = PublicFunctions.EvalAssignFromList(assignValue, item,_env,update,shouldUseLast);
        }



        public void EvalAssignFromNestedNumeric(string exp, CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult recsetResult,int update)
        {
            if( recsetResult.Item.Any())
                AssignWithFrame(new AssignValue(exp, WarewolfAtomToString(recsetResult.Item.Last())), update);
        }

        public void EvalDelete(string exp,int update)
        {
            _env =  PublicFunctions.EvalDelete(exp,update, _env);
        }

        public void CommitAssign()
        {
            _env = PublicFunctions.RemoveFraming(_env);
        }

        public void SortRecordSet(string sortField, bool descOrder, int update)
        {

            _env = PublicFunctions.SortRecset(sortField, descOrder,update, _env);
        }

        public string ToStar(string expression)
        {
            var exp = WarewolfDataEvaluationCommon.parseLanguageExpression(expression,0);
            if(exp.IsRecordSetExpression)
            {
                var rec = exp as LanguageAST.LanguageExpression.RecordSetExpression;
                if(rec != null)
                {
                return "[["+rec.Item.Name+"(*)."+rec.Item.Column+"]]";
                }
            }

            if (exp.IsRecordSetNameExpression)
            {
                var rec = exp as LanguageAST.LanguageExpression.RecordSetNameExpression;
                if (rec != null)
                {
                    return "[[" + rec.Item.Name + "(*)"+ "]]";

                }
            }
            return expression;
        }

        public IEnumerable<DataASTMutable.WarewolfAtom> EvalAsList(string expression, int update,bool throwsifnotexists = false)
        {
            var result = Eval(expression, update,throwsifnotexists);
            if (result.IsWarewolfAtomResult)
            {
                // ReSharper disable PossibleNullReferenceException
                var warewolfAtomResult = result as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult;
                if(warewolfAtomResult != null)
                {
                    var x = warewolfAtomResult.Item;
                // ReSharper restore PossibleNullReferenceException
                return new List<DataASTMutable.WarewolfAtom> { x };
            }
                throw new Exception("null when f# said it should not be");
            }
                // ReSharper disable RedundantIfElseBlock
            else
                // ReSharper restore RedundantIfElseBlock
            {
                // ReSharper disable PossibleNullReferenceException
                // ReSharper disable PossibleNullReferenceException
                var x = (result as CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult).Item;
                // ReSharper restore PossibleNullReferenceException
                return x.ToList();
            }
        }

        public IEnumerable<int> EvalWhere (string expression , Func<DataASTMutable.WarewolfAtom,bool> clause, int update)
        {
            return PublicFunctions.EvalWhere(expression, _env,update, clause);
        }

        public void ApplyUpdate(string expression, Func<DataASTMutable.WarewolfAtom, DataASTMutable.WarewolfAtom> clause, int update)
        {
            var temp = PublicFunctions.EvalUpdate(expression, _env,update,clause);
            _env = temp;

        }

        public HashSet<string> Errors { get; private set; }
        public HashSet<string> AllErrors
        {
            get;
            private set;
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public void AssignDataShape(string p)
        {
            var env = PublicFunctions.EvalDataShape(p,_env);
            _env = env;
        }

        public string FetchErrors()
        {
            return string.Join(Environment.NewLine,AllErrors.Union(Errors));
        }

        public bool HasErrors()
        {
            return Errors.Count(s => !string.IsNullOrEmpty(s))+ AllErrors.Count(s => !string.IsNullOrEmpty(s)) > 0;
        }


        public string EvalToExpression(string exp, int update)
        {
            return string.IsNullOrEmpty(exp) ? "" : WarewolfDataEvaluationCommon.evalToExpression(_env,update,exp);
        }

        public static string ConvertToIndex(string outputVar, int i)
        {
            var output =  WarewolfDataEvaluationCommon.parseLanguageExpression(outputVar,0);
            if(output.IsRecordSetExpression)
            {
                
                var outputidentifier = (output as LanguageAST.LanguageExpression.RecordSetExpression).Item;
                if(Equals(outputidentifier.Index, LanguageAST.Index.Star))
                return "[[" + outputidentifier.Name + "(" + i+ ")." +outputidentifier.Column+ "]]";
            }
            return outputVar;
        }

        public static bool IsRecordsetIdentifier(string assignVar)
        {
            try
            {
                var x = WarewolfDataEvaluationCommon.parseLanguageExpression(assignVar,0);
                return x.IsRecordSetExpression;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public static bool IsScalar(string assignVar)
        {
            try
            {
                var x = WarewolfDataEvaluationCommon.parseLanguageExpression(assignVar,0);
                return x.IsScalarExpression;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public static bool IsNothing(CommonFunctions.WarewolfEvalResult evalInp1)
        {
            return CommonFunctions.isNothing(evalInp1);
        }

        public static string GetPositionColumnExpression(string recordset)
        {
            var rec = WarewolfDataEvaluationCommon.parseLanguageExpression(recordset,0);
            if(rec.IsRecordSetExpression)
            {
                var index = (rec as LanguageAST.LanguageExpression.RecordSetExpression).Item;
                return "[[" + index.Name + "(" + "*" + ")." + WarewolfDataEvaluationCommon.PositionColumn + "]]";
            }
            if(rec.IsRecordSetNameExpression)
            {
                var index = (rec as LanguageAST.LanguageExpression.RecordSetNameExpression).Item;
                return "[[" + index.Name + "(" + "*" +")."+ WarewolfDataEvaluationCommon.PositionColumn + "]]";
            }
            return recordset;
        }

        public static  bool IsValidRecordSetIndex (string exp)
        {
            return PublicFunctions.IsValidRecsetExpression(exp);
        }


        public void AssignJson(List<IAssignValue> personFirsname)
        {
        }
    }
}
