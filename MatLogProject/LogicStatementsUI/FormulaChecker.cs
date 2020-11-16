using LogicStatements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicStatementsUI
{
    public class FormulaChecker
    {
        private  Formula[] _hypotheses;

        private Axiom[] _axioms;

        /// <summary>
        /// Обновление аксиом.
        /// </summary>
        /// <param name="axioms">аксиомы.</param>
        public void UpdateAxioms(Axiom[] axioms)
        {
            if (axioms == null)
                throw new ArgumentNullException();
            if (axioms.Length == 0)
                throw new ArgumentException("Axioms array was empty!");
            _axioms = axioms;
        }

        public bool IsAxiomOrHypothesesWasEnter() => _axioms != null || _hypotheses != null;

        /// <summary>
        /// Обновление гипотез.
        /// </summary>
        /// <param name="hypotheses">гипотезы.</param>
        public void UpdateHypotheses(Formula[] hypotheses)
        {
            if (hypotheses == null)
                throw new ArgumentNullException();
            if (hypotheses.Length == 0)
                throw new ArgumentException("Hypotheses array was empty!");
            _hypotheses = hypotheses;
        }

        /// <summary>
        /// Проверка вывода.
        /// </summary>
        /// <param name="formulas">Набор формул для проверки.</param>
        /// <returns> Отчет о проверке.</returns>
        public StringBuilder CheckWay(Formula[] formulas)
        {
            var result = new StringBuilder();            
            for (var i = 0; i < formulas.Length; i++) 
            {
                if(_axioms!=null)
                {
                    var res = IsAxiom(formulas[i]);
                    if(res.Item1)
                    {
                        //номер аксиомы (с 1)
                        result.AppendLine($"{i}. {formulas[i]}  :аксиома {res.Item2}");
                        continue;
                    }
                    
                }
                if(_hypotheses!=null)
                {
                    var res = IsHyp(formulas[i]);
                    if (res.Item1)
                    {
                        //номер гипотезы (с 1)
                        result.AppendLine($"{i}. {formulas[i]}  :гипотеза {res.Item2}");
                        continue;
                    }
                }

                var mp = IsMP(formulas, i, formulas[i]);
                if(mp.Item1)
                {

                    result.AppendLine($"{i}. {formulas[i]}  :MP {mp.Item2.Item1} ; {mp.Item2.Item2}");
                }
                else
                {
                    result = new StringBuilder($"строка {i}. Не удается обосновать.");
                    result.AppendLine();
                    result.Append($"{formulas[i]}");
                    return result;
                }
            }

            return result;
        }

        private Tuple<bool,int> IsAxiom(Formula formula)
        {
            for (var i = 0; i < _axioms.Length; i++)
            {
                if(_axioms[i].IsAnAxiom(formula))
                {
                    return new Tuple<bool, int>(true, i + 1);
                }
            }

            return new Tuple<bool, int>(false, -1);

        }

        private Tuple<bool,int> IsHyp(Formula formula)
        {
            for (var i = 0; i < _hypotheses.Length; i++)
            {
                if (string.Equals(_hypotheses[i].ToString(), formula.ToString()))
                {
                    return new Tuple<bool, int>(true, i + 1);
                }
            }

            return new Tuple<bool, int>(false, -1);
        }

        private Tuple<bool,Tuple<int,int>> IsMP(Formula[] formulas ,int index,Formula formula)
        {
            for (var i = 0; i < index; i++) 
            {
                var mp = Formula.IsModusPonensWasUsed(formulas[i], formula);
                if(mp != null)
                {
                    for (var j = 0; j < index; j++)
                    {
                        if(string.Equals(mp.ToString(),formulas[j].ToString()))
                        {
                            return new Tuple<bool, Tuple<int, int>>(true, new Tuple<int, int>(j, i));
                        }
                    }
                }
            }

            return new Tuple<bool, Tuple<int, int>>(false, null);
        }
    }
}
