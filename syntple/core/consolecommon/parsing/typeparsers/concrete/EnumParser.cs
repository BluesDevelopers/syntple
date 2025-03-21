﻿using syntple.core.consolecommon.helpers;
using syntple.core.consolecommon.parsing.typeparsers.interfaces;


namespace syntple.core.consolecommon.parsing.typeparsers
{
    public class EnumParser : TypeParserBase<Enum>
    {
        bool _parseEnumAsArray = false;
        public override object Parse(string toParse, Type typeToParse, ITypeParserContainer parserContainer)
        {
            object _returnVal;
            if (!_parseEnumAsArray && typeToParse.GetCustomAttribute<FlagsAttribute>() != null)
            {
                _parseEnumAsArray = true;
                Type _enumArrayType = typeToParse.MakeArrayType();
                ITypeParser _arrayParser = parserContainer.GetParser(_enumArrayType);
                Array _enumArray = _arrayParser.Parse(toParse, _enumArrayType, parserContainer) as Array;
                int _totalVal = 0;
                int _iter = 0;

                foreach (object enVal in _enumArray)
                {
                    if (_iter == 0) _totalVal = (int)enVal;
                    else
                    {
                        _totalVal = _totalVal | (int)enVal;
                    }
                    _iter++;
                }
                _returnVal = _totalVal;
                _parseEnumAsArray = false;
            }
            else _returnVal = Enum.Parse(typeToParse, toParse, true);
            return _returnVal;
        }
        public override string[] GetAcceptedValues(Type typeToParse)
        {
            if (typeToParse.IsEnum)
            {
                return Enum.GetNames(typeToParse);
            }
            else return new string[0] { };
        }
    }
}
