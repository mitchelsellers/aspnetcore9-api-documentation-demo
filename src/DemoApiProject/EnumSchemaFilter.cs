using System.ComponentModel;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DemoApiProject;

/// <summary>
///     This filter will do things to better control how enum values are displayed, the goal is to display a table of
///     options with descriptions,
///     with ReDoc even showing better naming/descriptions.
/// </summary>
public sealed class EnumSchemaFilter : ISchemaFilter
{
    /// <summary>
    ///     Supplies the custom schema behaviors
    /// </summary>
    /// <param name="schema"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        //We are only doing things if it is an enum
        var type = Nullable.GetUnderlyingType(context.Type) ?? context.Type;
        if (!type.IsEnum) return;

        //Create a table fo the value & description and use that to set the
        var table = string.Join("\n", Enum.GetValues(type)
            .Cast<Enum>()
            .Select(v => $"- {(int)(object)v} = {v} — {GetDescription(v)}"));

        schema.Description = (schema.Description ?? string.Empty) +
                             (string.IsNullOrWhiteSpace(schema.Description) ? "" : "\n\n") +
                             "Values:\n" + table;

        string GetDescription(Enum v)
        {
            var fi = type.GetField(v.ToString())!;
            return fi.GetCustomAttribute<DescriptionAttribute>()?.Description ?? "";
        }
    }
}