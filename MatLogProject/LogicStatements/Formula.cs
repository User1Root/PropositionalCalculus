using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LogicStatements
{
    /// <summary>
    /// Класс формулы.
    /// </summary>
    public class Formula
    {
        private readonly string _formulaString;

        private static string[] ModusPonenspatterns = new[]
        {
                @"^\((\([A-Za-z)(→¬&|]+?\))→(\([A-Za-z)(→¬&|]+\))\)$",
                @"^\((\w)→(\w)\)$",
                @"^\((\w)→(\([A-Za-z)(→¬&|]+\))\)$",
                @"^\((\([A-Za-z)(→¬&|]+\))→(\w)\)$"
        };

        public Formula(string formulaString)
        {
            if (!CheckString(formulaString))
                throw new ArgumentException("Строка не корректна.");
            this._formulaString = formulaString;
        }

        private bool CheckString(string formulaString)
        {
            var stack = new char[formulaString.Length];
            var peek = 0;
            for (var i = 0; i < formulaString.Length; i++)
            {
                if (formulaString[i] == ')' || formulaString[i] == '(' || formulaString[i] == '&'
                    || formulaString[i] == '|' || formulaString[i] == '→' || formulaString[i] == '¬'
                    || char.IsLetter(formulaString[i]))
                {

                    if (char.IsLetter(formulaString[i]))
                    {
                        stack[peek] = '#';
                    }
                    else
                        stack[peek] = formulaString[i];
                    
                    if (peek >= 4)
                    {
                        if(stack[peek - 4] =='(' && stack[peek] == ')')
                        {
                            if(stack[peek -3] =='#' && stack[peek -1] == '#')
                            {
                                if (stack[peek - 2] == '→' || stack[peek - 2] == '&' || stack[peek - 2] == '|')
                                {
                                    peek -= 4;
                                    stack[peek] = '#';
                                }
                            }
                        }
                    }
                    if (peek >= 3)
                    {
                        if (stack[peek - 3] == '(' && stack[peek] == ')')
                        {
                            if (stack[peek - 2] == '¬' && stack[peek - 1] == '#')
                            {
                                peek -= 3;
                                stack[peek] = '#';
                            }
                        }                        
                    }
                    peek++;
                }
                else
                    return false;
            }

            return peek == 1;
        }

        public override string ToString() => _formulaString.ToString();

        /// <summary>
        /// Выполняет Modus Ponens для заданного антецедент и формулы.
        /// A→B,A
        /// </summary>
        /// <param name="antecedent">Антецедент (A)</param>
        /// <param name="formula">Формула,над которой производится операция. (A→B)</param>
        /// <returns>Новая формула (B) или null, если нельзя выполнить операию.</returns>
        public static Formula ModusPonensOperation(Formula antecedent, Formula formula)
        {
            var tuple = GetAntecedentAndConsequent(formula);
            if (tuple == null)
                return null;
            var realAntecedent = tuple.Item1;
            var realConsequent = tuple.Item2;

            if (string.Equals(realAntecedent.ToString(), antecedent.ToString()))
            {
                return realConsequent;
            }
            else
                return null;

        }

        private static Tuple<Formula,Formula> GetAntecedentAndConsequent(Formula formula)
        {
            var antecedent = new StringBuilder();
            var consequent = new StringBuilder();
            var str = formula.ToString();
            if (str.Length < 5)
                return null;
            var indexs = new List<int>(4);
            var count = 1;
            var i = 1;

            if(str[i]=='(')
            {
                count++;
                antecedent.Append(str[i]);
                while (count != 1) 
                {
                    if (i >= str.Length)
                        return null;

                    i++;
                    if(str[i] == '(')
                    {
                        count++;
                    }
                    else if(str[i] == ')')
                    {
                        count--;
                    }
                    antecedent.Append(str[i]);
                }
            }
            else if(char.IsLetter(str[i]))
            {
                antecedent.Append(str[i]);               
            }
            else
                return null;
            i++;

            if (str[i] != '→')
                return null;

            i++;
            if (i >= str.Length)
                return null;

            if (str[i] == '(')
            {
                count++;
                consequent.Append(str[i]);
                while (count != 1)
                {
                    if (i >= str.Length)
                        return null;

                    i++;
                    if (str[i] == '(')
                    {
                        count++;
                    }
                    else if (str[i] == ')')
                    {
                        count--;
                    }
                    consequent.Append(str[i]);
                }
            }
            else if (char.IsLetter(str[i]))
            {
                consequent.Append(str[i]);

            }
            else
                return null;
            i++;

            if (str[i] != ')')
                return null;
            else
            {
                count--;
                i++;
                if (count != 0 || i != str.Length)
                {
                    return null;
                }
            }

            var antecedentFormula = new Formula(antecedent.ToString());
            var consequentFormula = new Formula(consequent.ToString());
            return new Tuple<Formula, Formula>(antecedentFormula, consequentFormula);
        }

        /// <summary>
        /// Проверяет, был при применен Modus Ponens.
        /// </summary>
        /// <param name="formula">>Формула,над которой производится операция. (A→B)</param>
        /// <param name="consequent">Консеквентом. (B)</param>
        /// <returns>Предпологаемый (A) или null, если нельзя выполнить операию.</returns>
        public static Formula IsModusPonensWasUsed(Formula formula, Formula consequent)
        {
            var tuple = GetAntecedentAndConsequent(formula);
            if (tuple == null)
                return null;
            var realAntecedent = tuple.Item1;
            var realConsequent = tuple.Item2;

            if (string.Equals(realConsequent.ToString(), consequent.ToString()))
            {
                return realAntecedent;
            }
            else
                return null;

        }
    }
}
/*  foreach (var pattern in ModusPonenspatterns)
            {
                var matches = Regex.Matches(formula.ToString(), pattern);
                foreach(Match match in matches)
                {
                    if (match.Groups.Count == 3)
                    {
                        var realAntecedent = match.Groups[1].Value;//A

                        var realConsequent = match.Groups[2].Value;//B

                        try
                        {
                            var realAntecedentFormula = new Formula(realAntecedent);
                            var realConsequentFromula = new Formula(realConsequent);
                            return new Tuple<Formula, Formula>(realAntecedentFormula, realConsequentFromula);
                        }
                        catch(ArgumentException)
                        {
                            continue;
                        }                                                
                    }
                }              
            }*/