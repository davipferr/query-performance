using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Reflection;

namespace QueryPerformance.Mapping
{
    public class Utils
    {
        public static object GetNonNullValuesInObject(object objectOrProp)
        {
            if (objectOrProp == null) return null;

            Type runtimeType = objectOrProp.GetType();

            if (objectOrProp is string propStringValue)
            {
                return string.IsNullOrEmpty(propStringValue) ? null : propStringValue;
            }
            else if (runtimeType.IsClass)   
            {
                var expando = new ExpandoObject() as IDictionary<string, object>;
                bool hasValidProperties = false;

                foreach (PropertyInfo prop in runtimeType.GetProperties())
                {
                    // Retorna o valor da propriedade
                    // Retorna um 'object' porque a propriedade pode ser vários qualquer tipos diferentes
                    var propValue     = prop.GetValue(objectOrProp);
                    var filteredValue = GetNonNullValuesInObject(propValue);

                    if (filteredValue != null)
                    {
                        expando?.Add(prop.Name, filteredValue);
                        hasValidProperties = true;
                    }
                }

                return hasValidProperties ? expando : null;
            }

            return objectOrProp;
        }
        
        public static string StringRepresentation(object obj, string indent = "")
        {
            if (obj == null) return "Objeto enviado está vázio";

            var result = new System.Text.StringBuilder();

            if (obj is IDictionary<string, object> dict)
            {
                foreach (var keyValuePair in dict)
                {
                    result.Append($"{indent}{keyValuePair.Key}: ");

                    if (keyValuePair.Value is IDictionary<string, object>)
                    {
                        result.AppendLine();
                        result.Append(StringRepresentation(keyValuePair.Value, indent + "-"));
                        continue;
                    }

                    result.AppendLine();
                }

                return result.ToString();
            }

            return result.AppendLine(obj.ToString()).ToString();
        }
    }
}