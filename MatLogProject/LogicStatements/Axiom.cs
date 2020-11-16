using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LogicStatements
{
    /// <summary>
    /// Класс аксиомы.
    /// </summary>
    public class Axiom : Formula
    {
        private readonly string _stringPattern;

        public Axiom(string formulaString):base(formulaString)
        {
            _stringPattern = CreatePattern(formulaString);
        }

        /// <summary>
        /// Проверяет является ли формула данной аксиомой.
        /// </summary>
        /// <param name="formula">Формула для проверки.</param>
        /// <returns>Является ли формула данной аксиомой.</returns>
        public bool IsAnAxiom(Formula formula)
        {
            var match = Regex.Match(formula.ToString(), this._stringPattern);
            if (match.Groups.Count == 0)
                return false;

            if (string.Equals(match.Groups[0].Value, formula.ToString()))
                return true;

            return false;
        }

        private string CreatePattern(string formulaString)
        {
            var result = new StringBuilder();
            var dictOfLetter = new Dictionary<char, int>();
            var number = 1;
            var groupPattern = @"([A-Za-z)(→¬&|]+)";
            foreach (var symbol in formulaString)
            {
                if(char.IsLetter(symbol))
                {
                    if(dictOfLetter.ContainsKey(symbol))
                    {
                        var numOfGroup = dictOfLetter[symbol];
                        result.Append($@"\{numOfGroup}");                      
                    }
                    else
                    {
                        dictOfLetter.Add(symbol, number);
                        result.Append(groupPattern);
                        number++;
                    }
                }
                else if(symbol == ')' || symbol =='('|| symbol == '|')
                {
                    result.Append($@"\{symbol}");
                }
                else
                {
                    result.Append(symbol);
                }
            }

            return result.ToString();
        }
    }
}
