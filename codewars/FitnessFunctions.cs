using System.Reflection;

namespace codewars;

public class FitnessFunctions
{
    [Fact]
    public void VerifyThatTestMethodNamesStartWithVerify()
    {
        // Get all types in the current assembly
        var types = Assembly.GetExecutingAssembly().GetTypes();

        // Filter out test classes whose names end with "Tests"
        var testClasses = types.Where(t => t.Name.EndsWith("Tests") && t.IsClass);

        // Collect all failing methods
        var failingMethods = new List<string>();

        foreach (var testClass in testClasses)
        {
            // Get all public methods of the test class that start with "Verify" and have the Theory/Fact attribute
            var methods = testClass.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                .Where(method => method.GetCustomAttributes().Any(attr => attr.GetType() == typeof(TheoryAttribute)) ||
                                 method.GetCustomAttributes().Any(attr => attr.GetType() == typeof(FactAttribute)));

            // Filter out methods that do not meet the criteria
            var failingMethodsInClass = methods
                .Where(method => !method.Name.StartsWith("Verify"));

            failingMethods.AddRange(failingMethodsInClass.Select(method => $"{method.Name} in class {testClass.FullName}"));
        }

        // Assert once for all failing methods
        failingMethods.Should().BeEmpty($"The following test methods do not adhere to the naming convention: {string.Join("\n", failingMethods)}. All test methods should start with 'Verify'.");
    }
}
