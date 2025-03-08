using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

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
        
        public static bool CompareObjects(object source, object target, out string differences)
        {
            var differencesBuilder = new StringBuilder();

            // Handle null cases
            if (source == null && target == null)
            {
                differences = string.Empty;
                return true;
            }

            if (source == null || target == null)
            {
                differences = $"One object is null: Source is {(source == null ? "null" : "not null")}, Target is {(target == null ? "null" : "not null")}";
                return false;
            }

            // Get types
            Type sourceType = source.GetType();
            Type targetType = target.GetType();

            // Check if types match
            if (sourceType != targetType)
            {
                differences = $"Type mismatch: Source type is {sourceType.Name}, Target type is {targetType.Name}";
                return false;
            }

            bool areEqual = true;
            
            // Get all readable properties
            var properties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                       .Where(p => p.CanRead);

            foreach (PropertyInfo prop in properties)
            {
                object sourceValue = prop.GetValue(source);
                object targetValue = prop.GetValue(target);

                // Handle null comparisons
                if (sourceValue == null || targetValue == null)
                {
                    if (sourceValue != targetValue)
                    {
                        areEqual = false;
                        differencesBuilder.AppendLine($"Property '{prop.Name}':");
                        differencesBuilder.AppendLine($"  Source: {sourceValue ?? "null"}");
                        differencesBuilder.AppendLine($"  Target: {targetValue ?? "null"}");
                    }
                    continue;
                }

                // Handle complex types (recursive comparison)
                if (!prop.PropertyType.IsPrimitive && 
                    prop.PropertyType != typeof(string) && 
                    prop.PropertyType != typeof(DateTime) &&
                    !prop.PropertyType.IsEnum)
                {
                    string nestedDifferences;
                    if (!CompareObjects(sourceValue, targetValue, out nestedDifferences))
                    {
                        areEqual = false;
                        differencesBuilder.AppendLine($"Complex property '{prop.Name}' differs:");
                        differencesBuilder.AppendLine(nestedDifferences.Split('\n')
                                          .Select(line => "  " + line)
                                          .Aggregate((a, b) => a + Environment.NewLine + b));
                    }
                    continue;
                }

                // Simple value comparison
                if (!object.Equals(sourceValue, targetValue))
                {
                    areEqual = false;
                    differencesBuilder.AppendLine($"Property '{prop.Name}':");
                    differencesBuilder.AppendLine($"  Source: {sourceValue}");
                    differencesBuilder.AppendLine($"  Target: {targetValue}");
                }
            }

            differences = differencesBuilder.ToString().TrimEnd();
            return areEqual;
        }
    } 
}
