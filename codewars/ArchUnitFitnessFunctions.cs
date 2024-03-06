namespace codewars;

using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.Fluent;
//add a using directive to ArchUnitNET.Fluent.ArchRuleDefinition to easily define ArchRules
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using System.Reflection;
using ArchUnitNET.xUnit;

public class ArchUnitFitnessFunctions
{
    [Fact]
    public void VerifyThatTestMethodNamesStartWithVerify()
    {
        var architecture = new ArchLoader().LoadAssemblies(typeof(ArchUnitFitnessFunctions).Assembly).Build();

        var rule = Classes().That().HaveNameEndingWith("Tests").Should().HaveMethodMemberWithName("Verify*");

        rule.Check(architecture);
    }
}
